    Regex regex = new Regex(@"^.*\/globalframeset\.esp.*$");
    using (var browser = IE.AttachTo<IE>(Find.ByUrl(regex), 12))
    {
        if (browser != null)
        {
            browser.AutoClose = false;
    
            var iFrame = browser.Frame(Find.ById("GlobalWrapper"));
    
            if (iFrame != null)
            {
                var frame = iFrame.Frame(Find.ByName("frGlobalNav"));
    
                if (frame != null)
                {
                    frame.TextField(Find.ByName("findtext")).Value = person.MedicalRecordNumber;
 
                    // This code is setting the DDL called "filtertype" to a value of "ID"
                    frame.SelectList(Find.ByName("filtertype")).SelectByValue("ID");
    
                    Regex buttonRegex = new Regex(@"^.*\/go_text\.gif.*$");
                    frame.Image(Find.BySrc(buttonRegex)).ClickNoWait();
                }
            }
    
            browser.BringToFront();
        }
    }
