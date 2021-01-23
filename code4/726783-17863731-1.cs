    window.TextInput += (sender, args) =>
    {
        if (args.ControlText == "\x14") // Ctrl+T
        {
            "".Translate(true);
        }
        if (args.ControlText == "\x09") // Ctrl+I
        {
            "".Translate(true, true);
        }
    };
    public static class LocalExtensions
    {
        private static Dictionary<string,SortedDictionary<string,string>> languages = new Dictionary<string,SortedDictionary<string,string>>(5);
        private static bool autoAdd;
        public static bool interactiveAdd;
        public static string Translate(this String phrase, bool autoAdd, bool interactive = false)
        {
            var cultures = CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures);
            var chooser = new Chooser(Application.Current.Windows[0], "Translate from English To:", cultures.Select(culture => culture.EnglishName));
            chooser.ShowDialog();
            var selectedCulture = cultures.First(candidate => candidate.EnglishName == chooser.selectedItem);
            Localize.SetDefaultCulture(selectedCulture);
            LocalExtensions.autoAdd = autoAdd;
            LocalExtensions.interactiveAdd = interactive;
            return phrase.Translate();
        }
        public static string Translate(this String phrase)
        {
            return phrase.Translate(CultureInfo.CurrentCulture);
        }
        public static string Translate(this String phrase, CultureInfo culture) {
            if (String.IsNullOrWhiteSpace(phrase)) return phrase;
            var lang = culture.TwoLetterISOLanguageName;
            SortedDictionary<string,string> translations;
            if (!Directory.Exists(@"Languages"))
            {
                return phrase;
            }
            var pathName = FindFile(@"Languages\" + lang + ".xml");
            if ( !languages.ContainsKey(lang) ) {
                try {
                    var xaml = File.ReadAllText(pathName, Encoding.UTF8);
                    translations = (SortedDictionary<string, string>)XamlServices.Parse(xaml);
                } catch(Exception) {
                    translations = new SortedDictionary<string,string>();
                }
                languages.Add(lang,translations);
            } else {
                translations = languages[lang];
            }
            if (translations.ContainsKey(phrase))
            {
                // return the translation for the specified phrase
                var tran = translations[phrase];
                var result = InteractiveUpdate(phrase, tran);
                if ( result != tran ) {
                    translations[phrase] = result;
                    SaveChanges(translations,pathName);
                }
                return translations[phrase];
            }
            // HACK: This is enabled by pressing CTRL+T on any window in the App.
            // Please note that any phrases in that window will not be translated
            // only phrases loaded in subsequent windows.
            if (LocalExtensions.autoAdd)
            {
                var result = InteractiveUpdate(phrase,phrase);
                translations.Add(phrase, result);
                SaveChanges(translations, pathName);
            }
            return phrase;
        }
