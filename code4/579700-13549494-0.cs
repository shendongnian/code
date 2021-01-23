    string ID = "";
    if (Properties.Settings.Default.IDs!=null && Properties.Settings.Default.IDs.Length>0) {
       ID = Properties.Settings.Default.IDs[0];
    }
    else {
       ID = "random";
       Properties.Settings.Default.IDs = new string[1];
       Properties.Settings.Default.IDs[0] = ID;
       Properties.Settings.Default.Save();
    }
