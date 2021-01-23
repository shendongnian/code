    public static string EncodeVideo(string Source, string Published)
    {   
     MediaHandler _mhandler = new MediaHandler(); 
     ..............
     ..............
     _mhandler.vinfo.ProcessID = Guid.NewGuid().ToString(); 
    // unique guid to attach with each process to identify proper object on progress bar and get info request
    // add media handler object in concurrent static list
     _lst.Add(_mhandler);
     return _mhandler.vinfo.ProcessID; // retuned unique identifier
    }
