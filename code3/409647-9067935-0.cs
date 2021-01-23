    private class FileIterator {
        public IEnumerable<Record> Iterate(string path) {
            var currentFiles = new List<Record>(
                Directory.GetFiles(path).Select(file => {
                    var fi = new FileInfo(file);
                    return new Record{FileName = fi.Name, FileSize = fi.Length};
                }
            ));
            var childFiles = Directory.GetDirectories(path).SelectMany(dir => Iterate(dir));
            return currentFiles.Union(childFiles);
        }
    }
