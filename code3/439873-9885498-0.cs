    public string CreateSPFile(string spServerURL, string spDocumenttargetUrl, string folder, string fileName, Stream fileStream, bool overwrite)
    {
        // I suggest skip this pre check since it internally opens a new site object
        // If you have to silenlty ignore non-existant SPSite you should catch a FileNotFoundException.
        if (SPSite.Exists(new Uri(spServerURL)))
        {
            // use the using construct to safely dispose the opened SPSite object
            using (SPSite site = new SPSite(spServerURL))
            {
                // SPWeb object opened with SPSite.OpenWeb() have to be disposed as well
                using (SPWeb web = site.OpenWeb())
                {
                    web.AllowUnsafeUpdates = true;
    
                    string targetUrl = SPUrlUtility.CombineUrl(web.ServerRelativeUrl, spDocumenttargetUrl);
                    
                    if (!String.IsNullOrEmpty(folder))
                    {
                        targetUrl = SPUrlUtility.CombineUrl(targetUrl, folder);
                    }
    
                    SPFolder target = web.GetFolder(target);
    
                    SPFileCollection files = target.Files;
                    target.Files.Add(fileName, fileStream, overwrite);
    
                    // no need to revert AllowUnsafeUpdates for newly opened webs
                    // web.AllowUnsafeUpdates = false;
                }
            }
        }
    }
