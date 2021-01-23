    public class MyControlBase
        : System.Windows.Forms.Button
    {
        public string MyProp { get; set; }
    }
    
    public class MyButton : MyControlBase
    {
        public string MyProperty { get; set; }
    }
--
    void Example()
    {
        var btn = new MyButton();
        var property = btn.MyProperty;
        var prop = btn.MyProp;
    }
