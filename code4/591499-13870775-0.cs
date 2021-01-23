    namespace WindowsFormsApplication10
    {
     public class character         // this is my class
        {
            public bool hair_black;
        }
        static class Program
        {
            public static character deviljin;
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                deviljin = new character();  // instance of my class
                deviljin.hair_black = true;      // initiating a member of the instance
            }
        }
    }
