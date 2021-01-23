    decimal a = 100.05m;
    decimal b = 100.50m;
    decimal c = 100.00m;
    CultureInfo ci = CultureInfo.GetCultureInfo("de-DE");
    string sa = String.Format(new CustomFormatter(ci), "{0}", a); // Will output 100,05
    string sb = String.Format(new CustomFormatter(ci), "{0}", b); // Will output 100,50
    string sc = String.Format(new CustomFormatter(ci), "{0}", c); // Will output 100
