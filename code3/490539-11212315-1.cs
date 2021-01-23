    using System;
    using System.Windows;
    using System.Data;
    using System.ComponentModel;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window , INotifyPropertyChanged
        {
            
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
    
                MyDataTable = new DataTable();
                MyDataTable.Columns.Add("Column1");
                MyDataTable.Columns.Add("Column2");
          
            }
            private DataTable _MyDataTable;
            public DataTable MyDataTable
            {
                get
                {
                    return _MyDataTable;
                }
                set
                {
                    _MyDataTable = value;
                    NotifyPropertyChanged("MyDataTable");
                }
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                DataRow row = MyDataTable.NewRow();
    
                MyDataTable.Rows.Add(row);
    
    
            }
    
    
    
            public event PropertyChangedEventHandler PropertyChanged;
            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(info));
                }
            }
        }
    }
