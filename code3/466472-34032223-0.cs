    using DiscUtils;
    public static void ReadIsoFile(string sIsoFile, string sDestinationRootPath)
            {
                Stream streamIsoFile = null;
                try
                {
                    streamIsoFile = new FileStream(sIsoFile, FileMode.Open);
                    DiscUtils.FileSystemInfo[] fsia = FileSystemManager.DetectDefaultFileSystems(streamIsoFile);
                    if (fsia.Length < 1)
                {
                    MessageBox.Show("No valid disc file system detected.");
                }
                else
                {
                    DiscFileSystem dfs = fsia[0].Open(streamIsoFile);                    
                    ReadIsoFolder(dfs, @"", sDestinationRootPath);
                    return;
                }
            }
            finally
            {
                if (streamIsoFile != null)
                {
                    streamIsoFile.Close();
                }
            }
        }
    public static void ReadIsoFolder(DiscFileSystem cdReader, string sIsoPath, string sDestinationRootPath)
        {
            try
            {
                string[] saFiles = cdReader.GetFiles(sIsoPath);
                foreach (string sFile in saFiles)
                {
                    DiscFileInfo dfiIso = cdReader.GetFileInfo(sFile);
                    string sDestinationPath = Path.Combine(sDestinationRootPath, dfiIso.DirectoryName.Substring(0, dfiIso.DirectoryName.Length - 1));
                    if (!Directory.Exists(sDestinationPath))
                    {
                        Directory.CreateDirectory(sDestinationPath);
                    }
                    string sDestinationFile = Path.Combine(sDestinationPath, dfiIso.Name);
                    SparseStream streamIsoFile = cdReader.OpenFile(sFile, FileMode.Open);
                    FileStream fsDest = new FileStream(sDestinationFile, FileMode.Create);
                    byte[] baData = new byte[0x4000];
                    while (true)
                    {
                        int nReadCount = streamIsoFile.Read(baData, 0, baData.Length);
                        if (nReadCount < 1)
                        {
                            break;
                        }
                        else
                        {
                            fsDest.Write(baData, 0, nReadCount);
                        }
                    }
                    streamIsoFile.Close();
                    fsDest.Close();
                }
                string[] saDirectories = cdReader.GetDirectories(sIsoPath);
                foreach (string sDirectory in saDirectories)
                {
                    ReadIsoFolder(cdReader, sDirectory, sDestinationRootPath);
                }
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
