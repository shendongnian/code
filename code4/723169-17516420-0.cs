    namespace WindowsFormsApplication1
    {
        public static class Program
        {
            public static EmployeeCumalitveList MyEmployeeList;
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                MyEmployeeList = new EmployeeCumalitveList();
                Application.Run(MyEmployeeList);
            }
        }
    }
