    class Program
    {
        public static void Main()
        {
            form = new MainForm();
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(form.OnUnhandledException);
            Application.Run(form);
        }
    }
  
