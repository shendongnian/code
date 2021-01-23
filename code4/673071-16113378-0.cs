    void Main()
    {
    	System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo( "es-MX" , true );
    	string date = "18/12/2012 11:09:39 p.m.";
    	
    	DateTime dt = new DateTime( 2012 , 12 , 18 , 11 , 9 , 39 ).AddHours( 12 );
    	
    	DateTime d;
    	string[] styles = {"dd/MM/yyyy hh:mm:ss tt"};
    	DateTime.TryParseExact(date, styles, cultureInfo, System.Globalization.DateTimeStyles.None, out d);
    	
    	d.Dump();
    }
