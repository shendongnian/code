    /// <summary>
    /// Testing various directory sources in a Unit Test project
    /// </summary>
    /// <remarks>
    /// I want to mimic the web app's App_Data folder in a Unit Test project:
    /// A) Using Copy to Output Directory on each data file
    /// D) Without having to set Copy to Output Directory on each data file
    /// </remarks>
    [TestMethod]
    public void UT_PathsExist()
    {
        // Gets bin\Release or bin\Debug depending on mode
        string baseA = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        Console.WriteLine(string.Format("Dir A:{0}", baseA));
        Assert.IsTrue(System.IO.Directory.Exists(baseA));
        // Gets bin\Release or bin\Debug depending on mode
        string baseB = AppDomain.CurrentDomain.BaseDirectory;
        Console.WriteLine(string.Format("Dir B:{0}", baseB));
        Assert.IsTrue(System.IO.Directory.Exists(baseB));
        // Returns empty string (or exception if you use .ToString()
        string baseC = (string)AppDomain.CurrentDomain.GetData("DataDirectory");
        Console.WriteLine(string.Format("Dir C:{0}", baseC));
        Assert.IsFalse(System.IO.Directory.Exists(baseC));
        // Move up two levels
        string baseD = System.IO.Directory.GetParent(baseA).Parent.FullName;
        Console.WriteLine(string.Format("Dir D:{0}", baseD));
        Assert.IsTrue(System.IO.Directory.Exists(baseD));
        // You need to set the Copy to Output Directory on each data file
        var appPathA = System.IO.Path.Combine(baseA, "App_Data");
        Console.WriteLine(string.Format("Dir A/App_Data:{0}", appPathA));
        // C:/solution/UnitTestProject/bin/Debug/App_Data
        Assert.IsTrue(System.IO.Directory.Exists(appPathA));
        // You can work with data files in the project directory's App_Data folder (or any other test data folder) 
        var appPathD = System.IO.Path.Combine(baseD, "App_Data");
        Console.WriteLine(string.Format("Dir D/App_Data:{0}", appPathD));
        // C:/solution/UnitTestProject/App_Data
        Assert.IsTrue(System.IO.Directory.Exists(appPathD));
    }
