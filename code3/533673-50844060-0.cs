     static public void Search(string path, string fileType, List<string> temporaryFileList, List<string> errorList)
        {
            List<string> temporaryDirectories = new List<string>();
            string basicDirectory = string.Empty;
            
            string fixPath = @"C:\Users\" + Environment.UserName + @"\";
            
            if (path.Length != 0)
            { basicDirectory = path; }
            else { basicDirectory = fixPath; }
   
            string directories = "";
            int j = 0;
            int equals = 0;
            foreach (string item in Directory.GetDirectories(basicDirectory))
            {
                try
                {
                    directories = item;
                    bool end = true;
                    equals = j;
                    do
                    {
                        int folderNumber = Directory.GetDirectories(directories).Count();
                        int fileNumber = Directory.GetFiles(directories).Count();
                        if ((folderNumber != 0 || fileNumber != 0) && equals == j)
                        {
                            foreach (var item1 in Directory.GetDirectories(directories))
                            {
                                temporaryDirectories.Add(item1);
                            }
                            foreach (string fajlok in Directory.GetFiles(directories))
                            {
                                if (fajlok != string.Empty)
                                {
                                    if (fileType.Length == 0)
                                    {
                                        temporaryFileList.Add(fajlok);
                                    }
                                    else
                                    {
                                        if (fajlok.Contains(fileType))
                                        {
                                            temporaryFileList.Add(fajlok);
                                        }
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                            equals++;
                            for (int i = j; i < temporaryDirectories.Count;)
                            {
                                directories = temporaryDirectories[i];
                                j++;
                                break;
                            }
                        }
                        else
                        {
                            end = false;
                        }
                    } while (end);
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show( ex.Message,"Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    errorList.Add(directories);
                }
            }
        }
