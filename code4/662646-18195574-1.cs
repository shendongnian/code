    public class ChromeOptionsWithPrefs: ChromeOptions
    {
        public Dictionary<string,object> prefs { get; set; }
    }
    public static void Initialize()
    {
        var options = new ChromeOptionsWithPrefs();
        options.prefs = new Dictionary<string, object>
        {
            { "intl.accept_languages", "nl" }
        };
        _driver = new ChromeDriver(@"C:\path\chromedriver", options);
    }
