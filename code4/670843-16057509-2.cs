    public interface IMyClass
    {
        int I { get; set; }
        string S { get; set; }
    }
    public interface IMyControl
    {
        IMyClass Field { get; set; }
        event EventHandler<EventArgs> MyEvent;
    }
    public class MyControl : UserControl, IMyControl
    {
        public MyControl(IMyClass field)
        {
            this.Field = field;
        }
        public IMyClass Field { get; set; }
        public event EventHandler<EventArgs> MyEvent;
    }
    public class MyClass1 : IMyClass
    {
        public int I { get; set; }
        public string S { get; set; }
        public override string ToString()
        {
            return "I am a MyClass1!!!";
        }
    }
    public class MyClass2 : IMyClass
    {
        public int I { get; set; }
        public string S { get; set; }
        public override string ToString()
        {
            return "I am a MyClass2!!!";
        }
    }
    var control = someCondition ? new MyControl(new MyClass1()) : new MyControl(new MyClass2());
    
