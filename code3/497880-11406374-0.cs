    [Test]
    public void Loads_correct_labels_from_language()
    {
        using(new LanguageSwitchContext("fr"))
        {
           var okayString = MyResources.Okay_Button;
           Assert.Equals("your localized string here", okayString);
        }
    }
    public class LanguageSwitchContext : IDisposable
    {
        public CultureInfo PreviousLanguage { get; private set; }
        public LanguageSwitchContext(CultureInfo culture) 
        {
            PreviousLanguage = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = culture;
        }
        public LanguageSwitchContext(string language) 
        {
            //create culture from language
        }
        public void Dispose() 
        {
            System.Threading.CurrentThread.CurrentCulture = PreviousCulture;
        }
    }
