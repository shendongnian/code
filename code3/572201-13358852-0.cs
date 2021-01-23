    DateTime[] dts = new DateTime[4];
    dts[0] = DateTime.Now.AddDays(-15);
    dts[1] = DateTime.Now.AddDays(-4);
    dts[2] = DateTime.Now.AddDays(1);
    dts[3] = DateTime.Now.AddDays(4);
    
    DateTime dtMax = dts.Max();
    DateTime dtMin = dts.Min();
    string str = string.Empty;
    for (DateTime i = dtMin; i <= dtMax; i = i.AddDays(1))
    {
         str += i.ToString("MM.dd.yyyy");
         str += Environment.NewLine;
    }
