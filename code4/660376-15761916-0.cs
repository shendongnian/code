    public class YourMainForm : Form
    {
       protected int SomeUniqueID;
       ... rest of all code for the original class
    }
    
    public class FormInstance1 : YourMainForm
    {
        public FormInstance1() : base()
        { SomeUniqueID = 1;}
    }
    
    public class FormInstance2 : YourMainForm
    {
        public FormInstance1() : base()
        { SomeUniqueID = 2;}
    }
    
    public class FormInstance3 : YourMainForm
    {
        public FormInstance1() : base()
        { SomeUniqueID = 3;}
    }
