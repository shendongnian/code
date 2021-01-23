    public class MedinetParsing //  : MainPage -- we don't need this inheritance
    {
        private readonly MainPage _mainPage;
    
        public MadinetParsing(MainPage mainPage)
        {
            _mainPage = mainPage;
        }
    
        // your code here
    
        // use the next line instead of commented one
        // mittSchemaListBox.ItemsSource = mittSchemaList;
        _mainPage.mittSchemaListBox.ItemsSource = mittSchemaList;
    }
