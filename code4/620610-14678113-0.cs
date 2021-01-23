    public class MyClass
    {
        [Import("TheString")]
        public dynamic MyAddin { get; set; }
    }
    [Export("TheString", typeof(IMyAddin))]
    public class MyLogger : IMyAddin { }
    
    [Export("TheString")]
    public class MyToolbar { }
