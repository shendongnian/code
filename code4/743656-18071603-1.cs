        using Shell32;
        public IEnumerable<string> GetRecycleBinFilenames()
        {
            Shell shell = new Shell();
            Folder recycleBin = shell.NameSpace(10);
            foreach (FolderItem2 recfile in recycleBin.Items())
            {
                // Filename
                yield return recfile.Name;
                // full recyclepath
                // yield return recfile.Path;
            }
            Marshal.FinalReleaseComObject(shell);
        }
