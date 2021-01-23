     public static bool DebugMode = false;
    
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
    
                var form = new Form1();
                form.Load += (s, e) =>
                                 {
                                     if (!DebugMode)
                                     {
                                         form.Opacity = 0;
                                         form.ShowInTaskbar = false;
                                     }
                                 };
    
                form.FormClosing += (s, e) =>
                                        {
                                            // Breakpoint hits
                                        };
    
                Application.Run(form);
            }
