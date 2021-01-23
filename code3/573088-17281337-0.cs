    public void Application_OnBeginRequest(object sender, EventArgs e)
            {
                System.Globalization.CultureInfo NC = new System.Globalization.CultureInfo(1036, true);
                NC.NumberFormat.CurrencyDecimalDigits = 2;
                NC.NumberFormat.CurrencySymbol = "euro";
                NC.NumberFormat.CurrencyDecimalSeparator = ".";
                NC.NumberFormat.PercentDecimalSeparator = ".";
                NC.NumberFormat.NumberDecimalSeparator = ".";
                NC.NumberFormat.CurrencyGroupSeparator = "";
                NC.NumberFormat.PercentGroupSeparator = "";
                NC.NumberFormat.NumberGroupSeparator = "";
                System.Threading.Thread.CurrentThread.CurrentCulture = NC;
            }
