        private List<string> GetFiles(string folder, string filter)
        {
            var files = new List<string>();
            // To create a recursive Action, you have to initialize it to null,
            // and then reassign it. Otherwise the compiler complains that you're
            // using an unassigned variable.
            Action<string> getFilesInDir = null;
            getFilesInDir = new Action<string>(dir =>
                {
                    try
                    {
                        // get all the files in this directory
                        files.AddRange(Directory.GetFiles(dir, filter));
                        // and recursively visit the directories
                        foreach (var subdir in Directory.GetDirectories(dir))
                        {
                            getFilesInDir(subdir);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        // ignore exception
                    }
                });
            getFilesInDir(folder);
            return files;
        }
