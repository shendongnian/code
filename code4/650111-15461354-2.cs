    static class Program
        {
    
            [STAThread]
    
            static void Main()
            {
    
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Thread thread1 = new Thread(new ThreadStart(openForms));
                thread1.SetApartmentState(ApartmentState.STA);
                thread1.Start();
            }
            static Form1 frm;
            static void openForms()
            {
                 frm = new Form1();
                 Program1 p = new Program1();
                 Application.Run(frm);
            }
    
            public class Program1
            {
                private HELLO h;
                public Program1()
                {
                    h = new HELLO();
                }
            }
    
            public class HELLO
            {
                public HELLO()
                {
                    frm._Form1.ThreadSafe("Hello ");
                }
    
            }
        }
