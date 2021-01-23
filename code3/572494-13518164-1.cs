    public int Download(IMoniker pmk, IBindCtx pbc, uint dwBindVerb, int grfBINDF, IntPtr pBindInfo,
                                string pszHeaders, string pszRedir, uint uiCP)
            {
                // Get the display name of the pointer to an IMoniker interface that specifies the object to be downloaded.
                string name;
                pmk.GetDisplayName(pbc, null, out name);
                if (!string.IsNullOrEmpty(name))
                {
                    Uri url;
                    if (Uri.TryCreate(name, UriKind.Absolute, out url))
                    {
                        Debug.WriteLine("DownloadManager: initial URL is: " + url);
                        CreateBindCtx(0, out pbc);
                        RegisterCallback(pbc, url);
                        BindMonikerToStream(pmk, pbc);
    
                        return MyBrowser.Constants.S_OK;
                    }
                }
                return 1;
            }
