    class myClass
    {
        public myClass(Window1 instance)
        {
            instance.myGrid.Width= 512;
            //Window1 .myGrid.Width= 512; will not work because myGrid is not static.
        }
    }
    public partial class Window1 : Window
    {
        public Window1 ()
        {
             myClass m = new myClass(this);
        }
    }
