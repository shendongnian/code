    string newestversion = sr.ReadToEnd();
    string currentversion = Application.ProductVersion;
    
    //Test if both versions are valid.
    //Debug.WriteLine(newestversion );
    //Debug.WriteLine(currentversion );
    
    Version vOnline=new Version(newestversion)
    Version vLocal=new Version(currentversion )
    
    if(vOnline > vLocal)
    {
    }
    else
    {
    }
