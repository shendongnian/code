    while ((users = sr.ReadLine()) != null)
    {
        string[] split = users.Split(',');
        if (split[1].Contains("SBL/FO/Rpt") ||
            split[1].Contains("SBL/Live Ins Apps") || 
            split[1].Contains("SBL/Port_Grp") || 
            split[1].Contains("SBL/Prices") || 
            split[1].Contains("SBL/SalesPerson"))
        {
            Console.WriteLine(split[1] + " " + split[0]);
            sw.WriteLine(split[0] + " , " + "Front Office - SalesPerson");
            sw.Flush();
        }
    }
