    // Copy the files and overwrite destination files if they already exist. 
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        string _currFileName = System.IO.Path.Combine(_SelectedPath, fileName);
                        System.IO.File.Copy(s, _currFileName, true);
                    }
