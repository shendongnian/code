    // Change culture
    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-IN");
    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-IN");
    // prints 12-29-2012
    Console.WriteLine(string.Format("{0:MM/dd/yyyy}", DateTime.Today));
    
    // Invariant culture, so ignore any culture-based settings
    // prints 12/29/2012
    Console.WriteLine(string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:MM/dd/yyyy}", DateTime.Today));
