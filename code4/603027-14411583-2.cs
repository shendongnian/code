    void Session_Start(object sender, EventArgs e)
            {
                // Code that runs when a new session is started
                xRefCodesRepository x = new xRefCodesRepository();            
                x.xref_LoadIntoSessionCache();
            }
