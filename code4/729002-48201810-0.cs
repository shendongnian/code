    class Program
    {
        static void Main(string[] args)
        {
            BuildCulture();
        }
        public static void BuildCulture()
        {
            if(cultureExist())
                CultureAndRegionInfoBuilder.Unregister("ku-KU");
            Console.WriteLine("Create the CultureAndRegionInfoBuilder...");
            var cib = new CultureAndRegionInfoBuilder("ku-KU", CultureAndRegionModifiers.None);
            cib.CultureEnglishName = "Kurdish (Kurdistan)";
            cib.RegionEnglishName = "Kurdistan";
            cib.CultureNativeName = "ßæÑÏí";
            var cia = new CultureInfo("ar-IQ");
            cib.NumberFormat = cia.NumberFormat;
            cib.GregorianDateTimeFormat = cia.DateTimeFormat;
            cib.TextInfo = cia.TextInfo;
            cib.CompareInfo = cia.CompareInfo;
            cib.KeyboardLayoutId = cia.KeyboardLayoutId;
            cib.RegionNativeName = "ßæÑÏÓÊÇä";
            cib.ThreeLetterISOLanguageName = "kur";
            cib.ThreeLetterISORegionName = "kur";
            cib.TwoLetterISORegionName = "ku";
            cib.ThreeLetterWindowsRegionName = "kur";
            cib.ISOCurrencySymbol = "USD";
            cib.CurrencyNativeName = "Dinary Kurdi";
            cib.CurrencyEnglishName = "Kurdish Dinar";
            var cinull = new CultureInfo("");
            cib.Parent = cinull;
            cib.ThreeLetterWindowsLanguageName = "kur";
            cib.TwoLetterISOLanguageName = "ku";
            cib.IetfLanguageTag = "kurdisk";
            cib.Register();
            cib.Save(@"C:\temp\kurdish.xml"); //Save created culture to XML document
            Console.WriteLine("Create and explore the custom culture...");
            var ci = new CultureInfo("ku-KU");
            Console.WriteLine("Name: . . . . . . . . . . . . . {0}", ci.Name);
            Console.WriteLine("EnglishName:. . . . . . . . . . {0}", ci.EnglishName);
            Console.WriteLine("NativeName: . . . . . . . . . . {0}", ci.NativeName);
            Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", ci.TwoLetterISOLanguageName);
            Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", ci.ThreeLetterISOLanguageName);
            Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", ci.ThreeLetterWindowsLanguageName);
            Console.Read();
        }
        //Register culture from XML file
        private void cmdCreateCultureFromXML()
        {
            if(cultureExist())
                CultureAndRegionInfoBuilder.Unregister("ku-KU");
            CultureAndRegionInfoBuilder cib = CultureAndRegionInfoBuilder.CreateFromLdml(@"C:\temp\kurdish.xml");
            cib.Register();
        }
        private static bool cultureExist()
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.UserCustomCulture);
            return cultures.Where(s => s.Name == "ku-KU").Any();
        }
    }
