    private static readonly Dictionary<string,IDisposable> dict = 
                                               CreateAndInitializeDictionary();
    private static Dictionary<string,IDisposable> CreateAndInitializeDictionary() {
       var d = new Dictionary<string,IDisposable>();
       .... // here add items 
       return d;
    }
