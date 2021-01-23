    public abstract class MyBaseClass 
    {
        public abstract void DoSomething();
    }
    
    public class MyDictClass : MyBaseClass
    {
        public readonly Dictionary<string, string> Dict = new Dictionary<string, string>();
    
        public override void DoSomething()
        {
            // So something with Dict
        }
    }
    
    public class MyTextClass : MyBaseClass
    {
        public string Text { get; set; }
    
        public override void DoSomething()
        {
            // So something with Text
        }
    }
