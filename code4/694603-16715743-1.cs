    public static void OpenURL(string Url)
    {
        var t = Type.GetTypeFromProgID("Shell.Application");
        dynamic o = Activator.CreateInstance(t);
        try
        {
            var instances = o.Windows();
            // Check if there is an Internet Explorer
            if (instances.Count > 0)
            {
                for (int i = 0; i < instances.Count; i++)
                {
                    var ie = instances.Item(i);
                    if (ie == null) continue;
                    var path = System.IO.Path.GetFileName((string)ie.FullName);
                    if (path.ToLower() == "iexplore.exe")
                    {
                        //Navigate and open in New Tab
                        ie.Navigate(Url, 0x10000);
                        return;
                    }
                }
            }
        }
        finally
        {
            Marshal.FinalReleaseComObject(o);
        }
        //No internet explorer found. Start a new onr
        Process.Start("IExplore.exe", Url);
    }
