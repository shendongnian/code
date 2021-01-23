    public interface IMyInterface
    {
        String MyProperty { get; }
    }
    public interface IMyInterface2
    {
        String MyProperty { get; }
    }
    // Implement BOTH interfaces
    public class MyClass : IMyInterface, IMyInterface2
    {
        string IMyInterface.MyProperty
        {
            get { return "I am Interface1.MyProperty"; }
        }
        string IMyInterface2.MyProperty
        {
            get { return "I am Interface2.MyProperty"; }
        }
        // Same Property Name on the class itself
        public String MyProperty
        {
            get { return "I am a brand new Property!"; }
        }
    }
      // Which can be used like so:
      var myClass = new MyClass();
      Console.WriteLine(((IMyInterface)myClass).MyProperty);
      Console.WriteLine(((IMyInterface2)myClass).MyProperty);
      Console.WriteLine(myClass.MyProperty);
    'I am Interface1.MyProperty'
    'I am Interface2.MyProperty'
    'I am a brand new Property!'
