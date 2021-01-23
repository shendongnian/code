    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;
    using System.ComponentModel;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker _worker;
        public MainWindow()
        {
            InitializeComponent();
            _worker = new BackgroundWorker();
            _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(_worker_RunWorkerCompleted);
        }
        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Done");
        }
        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(5000);
        }
        private void SetActiveTab(TabType type)
        {
            loaderTabs.Dispatcher.Invoke((Action)(() =>
            {
                //This is where the error happens when I try set the active tab back to tab1 
                loaderTabs.SelectedIndex = (int)type;
            }));
        }
        public void Login(string userName, string password)
        {
            try
                {
                   SetActiveTab(TabType.Loader);
                   //Processing... 
                   _worker.RunWorkerAsync();
               }
               catch (Exception)
               {
                   SetActiveTab(TabType.Login);
               }
           }
            enum TabType {Login, Loader};
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Login("user", "password");
            }
   
       }
    }
