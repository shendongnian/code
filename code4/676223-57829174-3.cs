                                int percentage = Percentage(bytesExtracted, bytesTotal);
                                lock (obj)
                                {
                                    progress?.Invoke(); // <-- Handle your progress updates here.
                                    progressReportingTimer.Restart();
                                }
                            }
                        };
                        // Block all threads until we sum the total size of all entries so that when we begin processing on the threadpool we 
                        // can report progress relative to the total.
                        lock (obj)
                            if (bytesTotal == -1)
                                foreach (var entry in zipFile.Entries)
                                    bytesTotal += entry.CompressedSize;
                        var array = zipFile.Entries.ToArray();
                        int index;
                        ZipEntry zipEntry;
                        // Iterate through the archive's entries sequentially despite being on multiple threads.
                        while (count < zipFile.Entries.Count && !token.IsCancellationRequested)
                        {
                            index = Interlocked.Increment(ref count);
                            if (index >= zipFile.Entries.Count)
                                return;
                            zipEntry = array[index];
                            if (count >= zipFile.Entries.Count)
                                return;
                            Interlocked.Add(ref bytesExtracted, zipEntry.CompressedSize);
                            zipEntry.Extract(destinationPath, ExtractExistingFileAction.OverwriteSilently);
                        }
                    }
                },
                token
                ));
            }
            Task.WaitAll(decompressors.ToArray());
        }
