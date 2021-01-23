    public partial class Form1 : Form
    {
         new Form2().InstanceMethod(); //Call with instance
         Form2.StaticMethod();   // call without creating instane
    }
    
    
    public partial class Form2 : Form
    {
        public void InstanceMethod()
        {}
        public static void StaticMethod()
        {}
    }
