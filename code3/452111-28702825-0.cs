    using (var isf = IsolatedStorageFile.GetUserStoreForApplication())
                    {
                        if (IsolatedStorageFile.IsEnabled)
                        {
                            if (isf.FileExists(localFileName))
                            {
                                using (var isfs = new IsolatedStorageFileStream(localFileName, FileMode.Open, isf))
                                {
                                    using (var sr = new StreamReader(isfs))
                                    {
                                        var data = sr.ReadToEnd();
                                        if (data != null)
                                        {
                                           ...
