    string Test = "17828.571428571";
    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
    double d = Convert.ToDouble(Test);
    double d2 = Convert.ToDouble(Test, CultureInfo.InvariantCulture);
    double d3 =  Convert.ToDouble(Test, NumberFormatInfo.InvariantInfo);
    
    string Test2 = "17828,571428571"; //Notice the comma in the string
    double d4 = Convert.ToDouble(Test2);
    Console.WriteLine("Using comma as decimal point: "+ d4);
