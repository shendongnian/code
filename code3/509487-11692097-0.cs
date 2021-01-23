    public static class Globals
    {
        public static XDocument ConfigFile = XDocument.Load("C:/somefile.xml");
    }
    public void SomeOtherFunctionSomewhere()
    {
        var configName = Globals.ConfigFile
            .Descendants("someconfigsection")
            .Descendants("configName")
            .First().Value;
    }
