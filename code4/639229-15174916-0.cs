    public partial class App : Application {
        public App() {
            this.Exit += App_Exit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }
        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            MessageBox.Show("Exception " + e.ExceptionObject.GetType().Name);
        }
        void App_Exit(object sender, ExitEventArgs e) {
            MessageBox.Show("Bye bye");
        }   
    }
