      protected void Page_PreInit(object sender, System.EventArgs e) {
    
    	System.Globalization.CultureInfo lang = null;
    	lang = new System.Globalization.CultureInfo("zh-CN");
    
    	System.Threading.Thread.CurrentThread.CurrentCulture = lang;
    	System.Threading.Thread.CurrentThread.CurrentUICulture = lang;
    
    }
