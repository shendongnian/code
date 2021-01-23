    //In dll project
    public static class MyAppSettings
    {
         public Icon AppIcon {get;set;}
    }
    //In Exe project
    static void Main()
    {
        MyAppSettings.AppIcon = Resources.Icon;  <--set here
        //Rest of starting App Code goes here
    }
