    static class Program
    {
        static void Main()
        {
            var climateFile = new ClimateFile();
            climateFile.InitSomeDataForSerialization();
    
            climateFile.SaveP51XFile("foo.P51X");
            var clone = ClimateFile.Load("foo.P51X");
        }
    }
