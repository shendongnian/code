    // Some interface
    public interface IHasText
    {
        string Text { get; set; }
    }
    
    // An implementation for the interface
    public class HasText : IHasText
    {
        public string Text
        {
            get;
            set;
        }
    }
