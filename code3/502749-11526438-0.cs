    using System.IO;
    using System.Collections.Generic;
    
    ...
    
                DirectoryInfo dir = new DirectoryInfo("C:\\yourfolder");
                FileInfo[] files = dir.GetFiles();
                List<string> prefix = new List<string>();
                List<int> count = new List<int>();
    
                foreach (FileInfo file in files)
                {
                    if (prefix.Count > 0)
                    {
                        Boolean AddNew = true;
                        for (int i = 0; i < prefix.Count; i++)
                        {
                            if (file.Name.Substring(0, 3) == prefix[i])
                            {
                                count[i]++;
                                AddNew = false;
                            }
                        }
                        if (AddNew)
                        {
                            prefix.Add(file.Name.Substring(0, 3));
                            count.Add(1);
                        }
                    }
                    else
                    {
                        prefix.Add(file.Name.Substring(0, 3));
                        count.Add(1);
                    }
                }
    
    ...
