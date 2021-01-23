    class myClass
    {
        public myClass(Form1 instance)
        {
            instance.myGrid.Name = "Test";
            //Form1.myGrid.Name = "Test"; will not work because myGrid is not static.
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
             myClass m = new myClass(this);
        }
    }
