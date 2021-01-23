    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Ionic.Zip;
    using Ionic.Zlib;
    
    namespace A1
    {
        public static class Program
        {
            static void Main(string[] args)
            {
                Console.ReadKey();
    
                CancellationToken cancellationToken = CancellationToken.None;
    
                string path = @"e:\1\";
                string zf1 = Path.Combine(path, "1.zip");
                string zf2 = Path.Combine(path, "2.zip");
                Stopwatch sw = new Stopwatch();
    
                List<string> zipFiles = new List<string>
                {
                    zf1,
                    zf2,
                };
                List<Action<string, string, CancellationToken>> methods = new List<Action<string, string, CancellationToken>>
                {
                    ExtractAllFilesFromZipFileV1,
                    //ExtractAllFilesFromZipFileV2,
                    //ExtractAllFilesFromZipFileV3,
                    ExtractAllFilesFromZipFileV4,
                    ExtractAllFilesFromZipFileV5,
                    ExtractAllFilesFromZipFileV4,
                    ExtractAllFilesFromZipFileV5,
                    ExtractAllFilesFromZipFileV4,
                    ExtractAllFilesFromZipFileV5,
                };
    
                zipFiles.Reverse();
                methods.Reverse();
    
                zipFiles.ForEach(f => methods.ForEach(m =>
                {
                    string fileName = Path.GetFileName(f);
                    string targetDirectory = path + Guid.NewGuid().ToString("N");
                    sw.Restart();
                    // Unzip
                    try
                    {
                        m(f, targetDirectory, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    sw.Stop();
                    Console.WriteLine("{0} processed by {1} in {2} seconds", fileName, m.GetMethodInfo().Name, sw.Elapsed.TotalSeconds.ToString("F3"));
                    Thread.Sleep(5 * 1000);
                    Directory.Delete(targetDirectory, true);
                    Thread.Sleep(5 * 1000);
                }));
            }
    
            private static void ExtractAllFilesFromZipFileV1(string zipFileName, string targetDirectory, CancellationToken cancellationToken)
            {
                using (ZipFile zipFile = new ZipFile(zipFileName))
                {
                    zipFile.ExtractAll(targetDirectory);
                }
            }
    
            private static void ExtractAllFilesFromZipFileV2(string zipFileName, string targetDirectory, CancellationToken cancellationToken)
            {
                using (ZipFile zipFile = new ZipFile(zipFileName))
                {
                    zipFile.Entries
                        .AsParallel()
                        .ForAll(v =>
                        {
                            v.Extract(targetDirectory);
                        });
                }
            }
    
    
            private static void ExtractAllFilesFromZipFileV3(string zipFileName, string targetDirectory, CancellationToken cancellationToken)
            {
                using (ZipFile zipFile = new ZipFile(zipFileName))
                {
                    int count = zipFile.Entries.Count;
    
                    Enumerable.Range(0, count)
                        .AsParallel()
                        .ForAll(v =>
                        {
                            cancellationToken.ThrowIfCancellationRequested();
    
                            using (ZipFile zf = new ZipFile(zipFileName))
                            {
                                // Get the right entry to extract
                                zf.Entries
                                    .Skip(v)
                                    .First()
                                    .Extract(targetDirectory);
                            }
                        });
                }
            }
    
            private static void ExtractAllFilesFromZipFileV4(string zipFileName, string targetDirectory, CancellationToken cancellationToken)
            {
                using (ZipFile zipFile = new ZipFile(zipFileName))
                {
                    // Get count of files, files and keep the lock on the file
                    int count = zipFile.Entries.Count();
    
                    // Cache instances of ZipFile used by threads
                    // Make sure that we have only open zip file not more than N times, where N is maxDop.
                    ConcurrentDictionary<int, ZipFile> dictionary = new ConcurrentDictionary<int, ZipFile>();
    
                    try
                    {
                        Parallel.For(0, count,
                            () =>
                            {
                                // GetOrAdd. Use existing open ZipFile or open a new one for this thread.
                                return dictionary.GetOrAdd(Thread.CurrentThread.ManagedThreadId, v =>
                                {
                                    return new ZipFile(zipFileName);
                                });
                            },
                            (int i, ParallelLoopState loopState, ZipFile zf) =>
                            {
                                cancellationToken.ThrowIfCancellationRequested();
    
                                // Get the right entry to extract
                                ZipEntry entry = zf.Entries
                                    .Skip(i)
                                    .First();
    
                                // Extract to a file
                                entry.Extract(targetDirectory);
    
                                return zf;
                            },
                            zf =>
                            {
                            });
                    }
                    finally
                    {
                        // Dispose cached ZipFiles
                        foreach (ZipFile zf in dictionary.Values)
                        {
                            zf.Dispose();
                        }
                    }
                } // using
            }
    
            private static void ExtractAllFilesFromZipFileV5(string zipFileName, string targetDirectory, CancellationToken cancellationToken)
            {
                using (ZipFile zipFile = new ZipFile(zipFileName))
                {
                    // Get count of files, files and keep the lock on the file
                    ICollection<ZipEntry> zipEntries = zipFile.Entries;
                    int count = zipEntries.Where(v => !v.IsDirectory).Count();
    
                    // Caclulate max DOP
                    int maxDop = (int)1.5 * Math.Min(count, Environment.ProcessorCount);
    
    
                    List<Tuple<int, long>> entries = zipEntries
                        .Select((v, i) => Tuple.Create(i, v))
                        .Where(v => !v.Item2.IsDirectory)
                        .Select(v => Tuple.Create(v.Item1, v.Item2.UncompressedSize))
                        .ToList();
    
                    // Load balance between threads
                    List<List<Tuple<int, long>>> groupedItems = entries.ToBuckets(maxDop, v => v.Item2 + 10 * 1024 * 1024).ToList();
    
                    // Ensure seq reading from zip file.
                    for (int i = 0; i < groupedItems.Count; ++i)
                    {
                        groupedItems[i] = groupedItems[i].OrderBy(v => v.Item1).ToList();
                    }
    
                    // Cache instances of ZipFile used by threads
                    // Make sure that we have open zip file not more than N times, where N is maxDop.
                    ConcurrentDictionary<int, Tuple<ZipFile, List<ZipEntry>>> dictionary = new ConcurrentDictionary<int, Tuple<ZipFile, List<ZipEntry>>>(maxDop, maxDop);
                    ParallelOptions parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = maxDop, };
    
                    try
                    {
                        Parallel.For(0, maxDop, parallelOptions,
                            () =>
                            {
                                // GetOrAdd. Re-use existing open ZipFile or open a new one for this thread.
                                return dictionary.GetOrAdd(Thread.CurrentThread.ManagedThreadId, v =>
                                {
                                    ZipFile zf = new ZipFile(zipFileName) { ExtractExistingFile = ExtractExistingFileAction.Throw, FlattenFoldersOnExtract = false, ZipErrorAction = ZipErrorAction.Throw, };
                                    zf.ExtractProgress += (sender, e) =>
                                    {
                                        cancellationToken.ThrowIfCancellationRequested();
                                    };
                                    return Tuple.Create(zf, zf.Entries.ToList());
                                });
                            },
                            (int j, ParallelLoopState loopState, Tuple<ZipFile, List<ZipEntry>> zf) =>
                            {
    
                                List<Tuple<int, long>> list = groupedItems[j];
                                for (int n = 0; n < list.Count; ++n)
                                {
                                    cancellationToken.ThrowIfCancellationRequested();
    
                                    int i = list[n].Item1;
    
                                    // Get the right entry to extract
                                    ZipEntry entry = zf.Item2[i];
                                    Debug.Assert(entry.UncompressedSize == list[n].Item2);
    
                                    // Extract to a file
                                    entry.Extract(targetDirectory);
                                }
    
                                return zf;
                            },
                            zf =>
                            {
                            });
                    }
                    finally
                    {
                        // Dispose cached ZipFiles
                        foreach (Tuple<ZipFile, List<ZipEntry>> zf in dictionary.Values)
                        {
                            try
                            {
                                zf.Item2.Clear();
                                zf.Item1.Dispose();
                            }
                            catch (ZlibException)
                            {
                                // There is a well known defect in Ionic.ZLib
                                // This exception may happen when you read only part of file (not entire file)
                                // and close its handle.
                                // Ionic.Zlib.ZlibException: Bad CRC32 in GZIP trailer. (actual(D202EF8D)!=expected(A39D1010))
                            }
                        }
                    }
                }
            }
    
    
            private static IEnumerable<List<T>> ToBuckets<T>(this IEnumerable<T> list, int bucketCount, Func<T, long> getWeight)
            {
                List<T> sortedList = list.OrderByDescending(v => getWeight(v)).ToList();
    
                List<long> runningTotals = Enumerable.Repeat(0L, bucketCount).ToList();
                List<List<T>> buckets = Enumerable.Range(0, bucketCount)
                    .Select(v => new List<T>(sortedList.Count / bucketCount))
                    .ToList();
    
                foreach (T item in sortedList)
                {
                    // MinBy runningTotal
                    int i = runningTotals.IndexOfMin();
                    // Add to bucket
                    runningTotals[i] += getWeight(item);
                    buckets[i].Add(item);
                }
    
                return buckets;
            }
    
            public static int IndexOfMin<T>(this IEnumerable<T> source, IComparer<T> comparer = null)
            {
                if (source == null)
                {
                    throw new ArgumentNullException(nameof(source));
                }
    
                if (comparer == null)
                {
                    comparer = Comparer<T>.Default;
                }
    
                using (IEnumerator<T> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return -1; // or maybe throw InvalidOperationException
                    }
    
                    int minIndex = 0;
                    T minValue = enumerator.Current;
    
                    int index = 0;
                    while (enumerator.MoveNext())
                    {
                        ++index;
                        if (comparer.Compare(enumerator.Current, minValue) < 0)
                        {
                            minIndex = index;
                            minValue = enumerator.Current;
                        }
                    }
    
                    return minIndex;
                }
            }
    
            public static int IndexOfMinBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer = null)
            {
                if (source == null)
                {
                    throw new ArgumentNullException(nameof(source));
                }
    
                if (comparer == null)
                {
                    comparer = Comparer<TKey>.Default;
                }
    
                using (IEnumerator<TSource> enumerator = source.GetEnumerator())
                {
                    if (!enumerator.MoveNext())
                    {
                        return -1; // or maybe throw InvalidOperationException
                    }
    
                    int minIndex = 0;
                    TKey minValue = selector(enumerator.Current);
    
                    int index = 0;
                    while (enumerator.MoveNext())
                    {
                        ++index;
                        TKey value = selector(enumerator.Current);
                        if (comparer.Compare(value, minValue) < 0)
                        {
                            minIndex = index;
                            minValue = value;
                        }
                    }
    
                    return minIndex;
                }
            }
        }
    }
