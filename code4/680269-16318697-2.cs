    public void Init() {
      this.Drives = new ObservableCollection<string>(DriveInfo.GetDrives()
                    .Where(item => item.IsReady && item.DriveType == DriveType.Removable)
                    .ToList());
    }
