    private void MyApplication_Startup(object sender, Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
    {
    	System.Globalization.CultureInfo newculture = System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
    	newculture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
    	newculture.DateTimeFormat.DateSeparator = "/";
    	System.Threading.Thread.CurrentThread.CurrentCulture = newculture;
    }
