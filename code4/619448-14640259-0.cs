    var cvt = new FontConverter();
    string s = cvt.ConvertToString(a.font.Font);
    Console.Out.WriteLine("Value is: " + s);
    System.Windows.Media.FontFamily g = new System.Windows.Media.FontFamily(s);
    Console.Out.WriteLine("Value is: " + g.ToString());
    this.textBox2.FontFamily = g;
