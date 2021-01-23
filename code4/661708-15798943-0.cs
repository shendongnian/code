    public partial class MainWindow
    {
        public void MethodInMainWindow()
        {
            // Don't need to create a new instance of MyClass
            MyClass.MethodInMyClass();
        }
    }
 
    public static class MyClass
    {
        public void MethodInMyClass()
        {
            //  ....
        }
    }
