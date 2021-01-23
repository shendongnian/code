                Shell32.Shell shl = null;
                Shell32.Folder folder = null;
                try
                {
                    shl = new Shell32.Shell();
                    folder = shl.NameSpace(Environment.CurrentDirectory);
                    foreach (Shell32.FolderItem file in folder.Items())
                    {
                        if (!RequiredFiles.Contains(file.path))
                        {/* do error handling */}
                    }
                }
                catch
                { }
                finally
                {
                    if (folder != null)
                    {
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(folder);
                        folder = null;
                    }
                    if (shl != null)
                    {
                        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shl);
                        shl = null;
                    }
                }
