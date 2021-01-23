    System.Globalization.CultureInfo calture = new System.Globalization.CultureInfo("ar-KW");
    System.Globalization.DateTimeFormatInfo dtf = calture.DateTimeFormat;
    dtf.Calendar = new System.Globalization.HijriCalendar(); 
    dtf.ShortDatePattern = "dd/MM/yyyy";
    dtf.MonthDayPattern = "MMMM";
    textbox1.Text = DateTime.Now.ToString("d", dtf);
