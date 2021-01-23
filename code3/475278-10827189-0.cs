                string strGacDir = @"C:\Windows\Microsoft.NET\assembly\GAC_32";
                string[] strDirs1 = System.IO.Directory.GetDirectories(strGacDir);
                string[] strDirs2;
                string[] strFiles;
                foreach (string strDir1 in strDirs1)
                {
                    strDirs2 = System.IO.Directory.GetDirectories(strDir1);
                    foreach (string strDir2 in strDirs2)
                    {
                        strFiles = System.IO.Directory.GetFiles(strDir2, "SlimD.dll");
                        foreach (string strFile in strFiles)
                        {
                            return true;
                        }
                    }
                }     
