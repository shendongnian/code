        /// <summary>
        /// Adds the supplied user into the (local) group
        /// </summary>
        /// <param name="userName">the full username (including domain)</param>
        /// <param name="groupName">the name of the group</param>
        /// <returns>true on success; 
        /// false if the group does not exist, or if the user is already in the group, or if the user cannont be added to the group</returns>
        public static bool AddUserToLocalGroup(string userName, string groupName)
        {
            DirectoryEntry userGroup = null;
            try
            {
                string groupPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0}/{1},group", Environment.MachineName, groupName);
                userGroup = new DirectoryEntry(groupPath);
                if ((null == userGroup) || (true == String.IsNullOrEmpty(userGroup.SchemaClassName)) || (0 != String.Compare(userGroup.SchemaClassName, "group", true, CultureInfo.CurrentUICulture)))
                    return false;
                String userPath = String.Format(CultureInfo.CurrentUICulture, "WinNT://{0},user", userName);
                userGroup.Invoke("Add", new object[] { userPath });
                userGroup.CommitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (null != userGroup) userGroup.Dispose();
            }
        }
