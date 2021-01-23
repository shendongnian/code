    using System;
    using System.Windows;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication3
    {
        public partial class MainWindow : Window
        {
            private readonly ObservableCollection<string> _data = new ObservableCollection<string>();
            internal ObservableCollection<string> Data
            {
                get { return _data; }
            }
    
            public MainWindow()
            {
                InitializeComponent();
                listbox.ItemSource = this.Data;
                Data.Add("XXX");
                Data.Add("YYY");
                new System.Threading.Thread(() =>
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Dispatcher.Invoke(new Action(() => Data.Add("ZZZ " + i)));
                        System.Threading.Thread.Sleep(1000);
                    }
                }).Start();
            }
        }
    }
