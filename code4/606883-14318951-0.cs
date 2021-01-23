    class Constants
    {
         public const string Aaaa = "aaaa:gggg";
         public const string Bbbb = "bbbb:gggg";
    }
...
    
    @switch (stringText)
    {
        case Constants.Aaaa:
            Do something...
            break;
        case Constants.Bbbb:
            Do something else...
            break;
     }
