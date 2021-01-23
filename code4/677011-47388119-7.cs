     namespace namespace1
        {
           
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                }
               
            }
    // the class StringData is defined in namespace namespace 1
            public class StringData
            {
                ObservableCollection<String> lst = new ObservableCollection<String>();
        
                public StringData()
                {
                    lst.Add("Abhishek");
                    lst.Add("Abhijit");
                    lst.Add("Kunal");
                    lst.Add("Sheo");
                }
                public ObservableCollection<String> GetStrings()
                {
                    return lst;
                }
            }
        }
