    public static int CompareResolutions(System.Drawing.Printing.PrinterResolution y, System.Drawing.Printing.PrinterResolution x)
    {
        if (x.X*x.Y > y.X*y.Y) 
            return 1;
        else if (x.X * x.Y < y.X * y.Y) 
            return -1;
        
        return 0;
    }
    public static System.Drawing.Printing.PrinterResolution GetMaxResolution(System.Drawing.Printing.PrintDocument pd)
    {
        return GetMaxResolution(pd.PrinterSettings);
    }
    public static System.Drawing.Printing.PrinterResolution GetMaxResolution(System.Drawing.Printing.PrinterSettings ps)
    {
        System.Drawing.Printing.PrinterResolution prMax = null;
        System.Collections.Generic.List<System.Drawing.Printing.PrinterResolution> ls = new System.Collections.Generic.List<System.Drawing.Printing.PrinterResolution>();
        for (int i = 0; i < ps.PrinterResolutions.Count; ++i)
        {
            System.Drawing.Printing.PrinterResolution pres = ps.PrinterResolutions[i];
            ls.Add(pres);
        } // Next i
        ls.Sort(CompareResolutions);
        if (ls.Count > 0)
            prMax = ls[0];
        ls.Clear();
        ls = null;
        return prMax;
    }
