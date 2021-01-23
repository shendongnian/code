        /// <summary>
        /// Loads all Drives of the Computer and returns a List.
        /// </summary>
        private List<DriveInfo> LoadDrives()
        {
            var drives = new List<DriveInfo>();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    drives.Add(drive);
                }
            }
            return drives;
        }
