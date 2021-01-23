    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace TestWPFApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new ViewModel();
            }
        }
    
    
        public class ViewModel
        {
            public ViewModel()
            {
                //Sample Data
                var recordList = new ObservableCollection<Record>();
                recordList.Add(new Record() { RecordNumber = "R1", Name = "R-Name-1" });
                recordList.Add(new Record() { RecordNumber = "R2", Name = "R-Name-2" });
                recordList.Add(new Record() { RecordNumber = "R3", Name = "R-Name-3" });
                recordList.Add(new Record() { RecordNumber = "R4", Name = "R-Name-4" });
    
                AccountList = new ObservableCollection<Account>();
                AccountList.Add(new Account() { AccountNumber = "A1111", Name = "A-Name-1", RecordList = recordList });
                AccountList.Add(new Account() { AccountNumber = "A2222", Name = "A-Name-2", RecordList = recordList });
                AccountList.Add(new Account() { AccountNumber = "A3333", Name = "A-Name-3", RecordList = recordList });
                AccountList.Add(new Account() { AccountNumber = "A4444", Name = "A-Name-4", RecordList = recordList });
            }
            public ObservableCollection<Account> AccountList { get; set; }
        }
    
        public class Account
        {
            public string AccountNumber { get; set; }
            public string Name { get; set; }
            public ObservableCollection<Record> RecordList { get; set; }
        }
    
        public class Record
        {
            public string RecordNumber { get; set; }
            public string Name { get; set; }
        }
    }
