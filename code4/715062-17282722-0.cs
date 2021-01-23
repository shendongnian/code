    [STAThread]
    static void Main(string[] args)
    {
        using (var _IExplore = new WatiN.Core.IE("http://www.yandex.ru"))
        {
            // _IExplore.Button(WatiN.Core.Find.ByName("nameOfButton")).Click(); //Clicks the button according to its name attribute
            _IExplore.Button(WatiN.Core.Find.ById("idOfButton")).Click(); //Clicks the button according to its id attribute
        }
    }
