    string batFilePath = @"c:\mockforbat.bat";
    using(var fs = new FileStream(batFilePath , FileMode.OpenOrCreate, FileAccess.Write))
    {
        using(var sw = new StreamWriter(fs))
        {
            string a = String.Format("{0,-24}{1,-5}{2,5}", "CostCenter", "CostObject", "ActivityType");
            sw.WriteLine(a);
        }
    }
