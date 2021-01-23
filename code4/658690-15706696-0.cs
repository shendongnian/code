       [STAThread]
       static void Main()
       { 
            MainUI form = new MainUI();
            AppDomain.CurrentDomain.UnhandledException += (s,e)=> {
                form.SetBusyState(false);
            };
            Application.ThreadException += (s,e)=> {
                form.SetBusyState(false);
            };  
            Application.Run(form);
        }
