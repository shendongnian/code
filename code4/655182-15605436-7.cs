    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Controller controller = new Controller();
                controller.RunForm1();
            }
        }
    }
