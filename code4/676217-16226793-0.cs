       public class ParallelZipFile
        {
            public static ParallelZipArchive OpenRead(string path)
            {
               
                return new ParallelZipArchive(ZipFile.OpenRead(path),path);
            }
        }
        public class ParallelZipArchive : IDisposable
        {
            internal ZipArchive _archive;
            internal string _path;
            internal ConcurrentQueue<ZipArchive> FreeReaders = new ConcurrentQueue<ZipArchive>();
    
            public ParallelZipArchive(ZipArchive zip,string path)
            {
                _path = path;
                _archive = zip;
                FreeReaders.Enqueue(zip);
            }
    
            public ReadOnlyCollection<ParallelZipArchiveEntry> Entries
            {
                get
                {
                    var list = new List<ParallelZipArchiveEntry>(_archive.Entries.Count);
                    int i = 0;
                    foreach (var entry in _archive.Entries)
                        list.Add(new ParallelZipArchiveEntry(i++, entry, this));
                    
                    return  new ReadOnlyCollection<ParallelZipArchiveEntry>(list);
                }
            }
    
    
            public void Dispose()
            {
                foreach (var archive in FreeReaders)
                    archive.Dispose();
            }
        }
        public class ParallelZipArchiveEntry
        {
            private ParallelZipArchive _parent;
            private int _entry;
            public string Name { get; set; }
            public string FullName { get; set; }
    
            public ParallelZipArchiveEntry(int entryNr, ZipArchiveEntry entry, ParallelZipArchive parent)
            {
                _entry = entryNr;
                _parent = parent;
                Name = entry.Name;
                FullName = entry.FullName;
            }
    
            public void ExtractToFile(string path)
            {
                ZipArchive value;
                Trace.TraceInformation(string.Format("Number of readers: {0}", _parent.FreeReaders.Count));
    
                if (!_parent.FreeReaders.TryDequeue(out value))
                    value = ZipFile.OpenRead(_parent._path);
    
                value.Entries.Skip(_entry).First().ExtractToFile(path);
    
    
    
                _parent.FreeReaders.Enqueue(value);
            }
        }
