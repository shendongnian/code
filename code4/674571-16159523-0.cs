    var toFile = Path.Combine(@"C:\Users\msilliman11\", 
        string.Format("Average{0}.txt", DateTime.Now.ToString("yyyyMMdd")));
    var dt = DateTime.Now;
    using (var fs = File.OpenWrite(toFile))
    using (TextWriter sw = new StreamWriter(fs))
    {
        sw.Write(string.Join(",", 
            "NA", 
            dt.Hour, 
            dt.Minute, 
            dt.Day,
            dt.Month,
            dt.Year,
            "ALTEST ",
            "ALTEST ",
            heatgrade, 
            "    ",
            "        ", 
            heatname,
            DT2.Columns[3],
            heatgrade,
            "OE2",
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty,
            " ",
            ","));
        foreach (var pair in RoundedValues.Zip(Elements, (a, b) => new { A = a, B = b }))
        {
            writeIt.Write(pair.B.ToString() + "," + pair.A.ToString() + ",");
        }
    }
