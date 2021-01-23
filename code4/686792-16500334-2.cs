    public sealed class DirectoryIterator
    {
        public static int Iterate(string root)
        {
            var iterator = new DirectoryIterator();
            iterator.iterate(root);
            return iterator.count;
        }
        private void iterate(string root)
        {
            foreach (string directory in Directory.EnumerateDirectories(root))
                iterate(directory);
            foreach (string file in Directory.EnumerateFiles(root, "*.txt"))
            {
                // load(file);
                ++count;
                // Now count is the actual number of files processed,
                // so you can use it for updateProgress()
            }
        }
        private int count;
        private DirectoryIterator(){}
    }
