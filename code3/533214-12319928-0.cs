    System.Windows.Forms.Screen s = null;
    System.Drawing.Point p = new System.Drawing.Point(0,0);
    Console.WriteLine("Using same instance of Screen:");
    s = System.Windows.Forms.Screen.FromPoint(p);
    for (int i = 0; i < 5; ++i)
    {
        Console.WriteLine(s.DeviceName);
    }
    Console.WriteLine();
    Console.WriteLine("Using new instance of Screen:");
    for (int i = 0; i < 5; ++i)
    {
        Console.WriteLine(System.Windows.Forms.Screen.FromPoint(p).DeviceName);
    }
