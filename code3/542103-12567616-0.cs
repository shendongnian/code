    public static void MINote(int MIWindowID, string Message)
    {
       System.IntPtr MIDispatchPtr = new IntPtr(MIWindowID);
       DMapInfo MIConnection = (DMapInfo)Marshal.GetObjectForIUnknown(MIDispatchPtr);
       MIConnection.Do(String.Format("Note \"Note from CSharp: {0}\"",Message));
       DMBApplications Applications = (DMBApplications) MIConnection.MBApplications;
       foreach (DMapBasicApplication mbApp in Applications) 
       {
          MIConnection.Do(String.Format("Note \"MB App. running in this MapInfo instance: {0}\"", mbApp.Name));
       } 
    }
