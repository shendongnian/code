    public Control GetWebBrowserControl()
    {
	    foreach (Control ctl in TabControl1.SelectedTab.Controls) {
		    if (ctl is WebBrowser) {
			    return ctl;
		    }
	    }
	    return null;
    }    
