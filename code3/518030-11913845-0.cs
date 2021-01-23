    double d = 1.5;
    
    Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");
    Console.WriteLine(d.ToString());            // 1,5
    Console.WriteLine(XmlConvert.ToString(d));  // 1.5
    
    Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    
    Console.WriteLine(d.ToString());            // 1.5
    Console.WriteLine(XmlConvert.ToString(d));  // 1.5
