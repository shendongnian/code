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
            var settingsFlags1 = MySettings.SettingA | MySettings.SettingB;
            var settingsFlags2 = MySettings.SettingB | MySettings.SettingC | MySettings.SettingD;
            int mySettings1 = (int)settingsFlags1;
            int mySettings2 = (int)settingsFlags2;
            Console.WriteLine("Analyse mySetting1");
            AnalyseSettings(mySettings1);
            Console.WriteLine("Analyse mySetting2");
            AnalyseSettings(mySettings2);
            Console.ReadKey();
        }
        private static void AnalyseSettings(int mySettings)
        {
    // ...
        }
    }
