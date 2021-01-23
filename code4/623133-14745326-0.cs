    class DirectoryHelper
    {
        public List<string> GetDirectories(string path)
        {
            List<string> list = new List<string>();
            EnumerateDictories(list, path);
            return list;
        }
        private void EnumerateDictories(IList<string> results, string path)
        {
            var parent = Directory.GetParent(path);
            if (parent != null)
            {
                EnumerateDictories(results, parent.FullName);
                results.Add(parent.FullName);
            }
        }
    }
