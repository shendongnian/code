    var hostnames = NetworkInformation.GetHostNames();
    foreach(var hn in hostnames)
    {
        if(hn.NetworkAdapter != null)
        {
            Debug.WriteLine("{0}:{1}", 
                hn.CanonicalName, hn.NetworkAdapter.NetworkAdapterId);
        }
        else
        {
            Debug.WriteLine(hn.CanonicalName);
        }
    }
