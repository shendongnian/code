    public interface IExample
    {
        string Word { get; set; }
        void DoIt();
    }
    public abstract class ExampleClass : IExample
    {
       public string Word { get; set; }
       public void DoIt();
    }
