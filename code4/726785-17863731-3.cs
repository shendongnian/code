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
            var pathName = FindFile("Languages\\" + lang + ".xml");
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
        private static void SaveChanges(SortedDictionary<string,string> translations, string pathName)
        {
                var writer = new StreamWriter(pathName, false, Encoding.UTF8);
                XamlServices.Save(writer, translations);
                writer.Close();
        }
        private static string InteractiveUpdate(String phrase, String tran)
        {
            // HACK: Interactive update will be enabled by pressing CTRL+I on any window.
            // The same caveat applies here as with autoAdd above.
            if (interactiveAdd && !phrase.StartsWith("pack:"))
            {
                interactiveAdd = autoAdd = false;
                
                var tb = new TextBox
                {
                    TextWrapping = TextWrapping.Wrap,
                    AcceptsReturn = true,
                    Height = double.NaN,
                    Width = double.NaN,
                    Text = tran
                };
                var te = new TextEntry(Application.Current.Windows[0],"Please translate:",tb,TextEntryType.AlphaNumeric);
                te.blurEnabled = false;
                te.ShowDialog();
                tran = tb.Text;
                interactiveAdd = autoAdd = true;
            }
            return tran;
        }
        private static string FindFile(string fileName)
        {
            var candidatePath = fileName;
            if (!File.Exists(fileName))
            {
                candidatePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + fileName;
                if (!File.Exists(candidatePath) && ApplicationDeployment.IsNetworkDeployed)
                {
                    candidatePath = ApplicationDeployment.CurrentDeployment.DataDirectory + "\\" + fileName;
                }
            }
            return candidatePath;
        }
    }
