    if (read.Contains("*"))
                        {
                            int i = read.IndexOf("*");
                            string path = read.Substring(0, i--);
                            string doc = read.Substring(i+1);
                            zip.AddSelectedFiles(doc, @path, true);
                        }
                        else
                        {
                            zip.AddFile(read);
                        }
