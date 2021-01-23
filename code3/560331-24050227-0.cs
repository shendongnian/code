    public static string AutoRenameFilename(FileInfo file)
        {
            var filename = file.Name.Replace(file.Extension, string.Empty);
            var dir = file.Directory.FullName;
            var ext = file.Extension;
            if (file.Exists)
            {
                int count = 0;
                string added;
                do
                {
                    count++;
                    added = "(" + count + ")";
                } while (File.Exists(dir + "\\" + filename + " " + added + ext));
                filename += " " + added;
            }
            return (dir + filename + ext);
        }
