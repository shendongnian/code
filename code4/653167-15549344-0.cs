    foreach (byte[] bytes in files)
    {
        ProjDocAttach prjd = new ProjDocAttach();
        prjd.ProjDocID = _Projectid;
        prjd.Data = bytes;
        // Save to database
    }
	
