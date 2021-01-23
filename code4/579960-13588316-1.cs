    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Results = new ObservableCollection<Tuple<string, string[]>>();
    
                FillListView("AAA", new string[] { "A1", "A2", "A3" });
                FillListView("BBB", new string[] { "B1", "B2", "B3" });
    
                DataContext = this;
            }
    
            public ObservableCollection<Tuple<string, string[]>> Results { get; private set; }
    
            private void FillListView(string header, string[] text)
            {
                Results.Add(Tuple.Create(header, text));
            }
        }
    }
