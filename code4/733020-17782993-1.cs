    class MyClass
    {
        CultureInfo currentCultureInfo;
        public MyClass()
        {
            //defaulting to en-US
            currentCultureInfo = new CultureInfo("en-US");
        }
        public void SetLanguageToEnglish()
        {
            currentCultureInfo = new CultureInfo("en-US");
        }
        public void SetLanguageToItalian()
        {
            currentCultureInfo = new CultureInfo("it-IT");
        }
        public string GetTranslation(string s)
        {
            //By the way, you should to the same to 'a' and 'rm', since they don't need to be instantiated each time. But I'll use your code to avoid confusion.
            Assembly a = Assembly.Load("read_display");
            ResourceManager rm = new ResourceManager("read_display.language.languageRes", a);
            return rm.GetString(s, currentCultureInfo);
        }
    }
