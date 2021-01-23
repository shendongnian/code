    using System;
    using System.Threading;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public bool IsBusy
            {
                get { return (bool)GetValue(IsBusyProperty); }
                set { SetValue(IsBusyProperty, value); }
            }
    
            public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(MainWindow), new PropertyMetadata(false));
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                IsBusy = true;
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    Thread.Sleep(2000);
    
                    IsBusy = false;
                }), System.Windows.Threading.DispatcherPriority.Render, null);
            }
        }
    }
