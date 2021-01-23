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
    using System.Reactive.Linq;
    using System.Reactive.Concurrency;
    namespace WpfApplication1
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
            InitializeComponent();
        }
        private static string StringWait(string str)
        {
            Thread.Sleep(10);
            return str;
        }
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            var query = from number in Enumerable.Range(1, 10000000)
                        select StringWait(number.ToString());
            var observableQuery = query.ToObservable(Scheduler.Default);
            observableQuery.ObserveOn(Dispatcher).Subscribe(n => Results.AppendText
                (string.Format("{0}\n",n)));
            
        }
      }
    }
