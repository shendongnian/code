        /// <summary>
        /// Interaction logic for App.xaml
        /// </summary>
        public partial class App : Application
        {
            protected override void OnExit(ExitEventArgs e)
            {
                Thread.Sleep(10000);
                MessageBox.Show("done");
                base.OnExit(e);
            }
        }
