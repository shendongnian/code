     static public void Search(string path, string fileType, List<string> temporaryFileList, List<string> errorList)
        {
            List<string> temporaryDirectories = new List<string>();
            
            //string fix = @"C:\Users\" + Environment.UserName + @"\";
            string fix = @"C:\";
            string folders = "";
            //Alap útvonal megadása 
            if (path.Length != 0)
            { folders = path; }
            else { path = fix; }
            
            int j = 0;
            int equals = 0;
            bool end = true;
            do
            {
                equals = j;
                int k = 0;
                try
                {
                    int foldersNumber = 
                    Directory.GetDirectories(folders).Count();
                    int fileNumber = Directory.GetFiles(folders).Count();
                    if ((foldersNumber != 0 || fileNumber != 0) && equals == j)
                    {
                        for (int i = k; k < 
                        Directory.GetDirectories(folders).Length;)
                        {
                            
                 temporaryDirectories.Add(Directory.GetDirectories(folders)[k]);
                            k++;
                        }
                        if (temporaryDirectories.Count == j)
                        {
                            end = false;
                            break;
                        }
                        foreach (string files in Directory.GetFiles(folders))
                        {
                            if (files != string.Empty)
                            {
                                if (fileType.Length == 0)
                                {
                                    temporaryDirectories.Add(files);
                                }
                                else
                                {
                                    if (files.Contains(fileType))
                                    {
                                        temporaryDirectories.Add(files);
                                    }
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    equals++;
                    for (int i = j; i < temporaryDirectories.Count;)
                    {
                        folders = temporaryDirectories[i];
                        j++;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    errorList.Add(folders);
                    for (int i = j; i < temporaryDirectories.Count;)
                    {
                        folders = temporaryDirectories[i];
                        j++;
                        break;
                    }
                }
            } while (end);
        }
