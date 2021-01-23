        /// <summary>
        /// Creates a virtual directory on the specified web site
        /// </summary>
        /// <param name="serverName">name of server</param>
        /// <param name="siteId">Site Id</param>
        /// <param name="directoryName">Virtual Directory Name</param>
        /// <param name="physicalPath">physical path of directory</param>
        /// <param name="bAnonymousLogon">Integrated Windows authentication or Anonymous Logon</param>
        /// <param name="defaultDoc">The default document for the site.</param>
        /// <returns>The Virtual Directory</returns>
        public DirectoryEntry CreateVirtualDirectory(string serverName, int siteId, string directoryName, string physicalPath, bool bAnonymousLogon, string defaultDoc)
        {
            try
            {
                // Does the directory exist already?
                DirectoryEntry vDir = GetVirtualDirectory(serverName, siteId, directoryName);
                if (vDir != null)
                {
                    // Yes, it does, no need to create
                    _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirAlreadyExists, directoryName, siteId));
                }
                else
                {
                    // No, we have some creating to do
                    DirectoryEntry root = new DirectoryEntry("IIS://" + serverName + "/W3SVC/" + siteId.ToString(CultureInfo.CurrentUICulture) + "/Root");
                    vDir = root.Children.Add(directoryName, IisVirtualDirectory);
                    vDir.CommitChanges();
                    _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreated, directoryName, siteId));
                }
                // Created or not, we want to set the virtual directory's properties
                // We take a risk here by using literals rather than variables (need to make sure the
                // log value is the same as the actual entry)
                // But its not really much of a risk - the main reason for logging is to record progress
                // through the "set" operation
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreatePath, physicalPath));
                vDir.Properties["Path"][0] = physicalPath;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAccessRead, true.ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["AccessRead"][0] = true;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAccessExecute, true.ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["AccessExecute"][0] = true;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAccessWrite, false.ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["AccessWrite"][0] = false;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAccessScript, false.ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["AccessScript"][0] = false;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAuthNtlm, (!bAnonymousLogon).ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["AuthNTLM"][0] = !bAnonymousLogon;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAuthAnon, bAnonymousLogon.ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["AuthAnonymous"][0] = bAnonymousLogon;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateDefaultDoc, true.ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["EnableDefaultDoc"][0] = true;
                if (!string.IsNullOrEmpty(defaultDoc))
                {
                    _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateDefaultDoc,
                                              defaultDoc.ToString(CultureInfo.CurrentUICulture)));
                    vDir.Properties["DefaultDoc"][0] = defaultDoc + ",default.htm,default.aspx,default.asp";
                }
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateDirBrowse, false.ToString(CultureInfo.CurrentUICulture)));
                vDir.Properties["EnableDirBrowsing"][0] = false;
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAppFriendlyName, directoryName));
                vDir.Properties["AppFriendlyName"][0] = directoryName;    // The name of the application
                if (_InstalledIISVersion >= IisVersion.Iis6)
                {
                    _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateAppPool, directoryName));
                    vDir.Properties["AppPoolId"][0] = directoryName;
                }
                // Commit the changes to the directory
                vDir.CommitChanges();
                // Create out-of-process application
                vDir.Invoke("AppCreate", false);
                
                _Logger.Log(VirDirCreateSetUp);
                return vDir;
            }
            catch (Exception ex)
            {
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirCreateException, directoryName, siteId));
                _Logger.Log(ex);
                throw ;
            }
        }
