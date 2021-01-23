    [Flags]
    public enum MySettings
    {
        SettingA=1,
        SettingB=2,
        SettingC=4,
        SettingD=8
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte mySettings1 = 7;
            byte mySettings2 = 2;
            Console.WriteLine("Analyse mySetting1");
            AnalyseSettings(mySettings1);
            Console.WriteLine("Analyse mySetting2");
            AnalyseSettings(mySettings2);
            Console.ReadKey();
        }
        private static void AnalyseSettings(byte mySettings)
        {
            byte maskA = 1;
            byte maskB = 2;
            byte maskC = 4;
            byte maskD = 8;
            // Compare with bitwise and 
            if ((mySettings & maskA) == maskA)
            {
                Console.WriteLine("A Selected");
            }
            if ((mySettings & maskB) == maskB)
            {
                Console.WriteLine("B Selected");
            }
            if ((mySettings & maskC) == maskC)
            {
                Console.WriteLine("C Selected");
            }
            if ((mySettings & maskD) == maskD)
            {
                Console.WriteLine("D Selected");
            }
        }
    }
