        /// <summary>
        /// Determines whether the directory entry exists on the specified site
        /// </summary>
        /// <param name="serverName">name of server</param>
        /// <param name="siteId">site id</param>
        /// <param name="directoryName">virtual directory name</param>
        /// <returns>the Virtual Directory, if it exists, otherwise null</returns>
        private DirectoryEntry GetVirtualDirectory(string serverName, int siteId, string directoryName)
        {
            try
            {
                DirectoryEntry root = new DirectoryEntry("IIS://" + serverName + "/W3SVC/" + siteId.ToString(CultureInfo.CurrentUICulture) + "/Root");
                foreach (DirectoryEntry entry in root.Children)
                {
                    if (0 == String.Compare(directoryName, entry.Name, true, CultureInfo.CurrentUICulture))
                    {
                        _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirFound, directoryName, serverName));
                        return entry;
                    }
                }
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirNotFound, directoryName, serverName));
                return null;
            }
            catch (Exception ex)
            {
                _Logger.Log(String.Format(CultureInfo.CurrentUICulture, VirDirException, directoryName, siteId, serverName));
                _Logger.Log(ex);
                throw;
            }
        }
