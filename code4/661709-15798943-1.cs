    public partial class MainWindow
    {
        public void MethodInMainWindow()
        {
            // Don't need to create a new instance of MyClass
            MyClass.MethodInMyClass();
        }
    }
 
    public class MyClass
    {
        public static void MethodInMyClass()
        {
            //  ....
        }
    }
