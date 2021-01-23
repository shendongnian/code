        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new SimpleVM();
            }
        }
    
        public class SimpleVM
        {    
            private string _mySimpleItem;
            private string _myNewSimpleItem;
            private bool isNew = true;
    
            #region properties
    
            public ObservableCollection<string> mySimpleItems { get; set; }
    
            public string mySimpleItem
            {
                get { return _mySimpleItem; }
                set
                {
                    _mySimpleItem = value;
                    if (_mySimpleItem != null)
                    {
                        isNew = false;
                        MessageBox.Show(_mySimpleItem);
                    }
                    else
                        isNew = true;
                }
            }
    
            public string myNewSimpleItem
            {
                get { return _myNewSimpleItem; }
                set
                {
                    _myNewSimpleItem = value;
                    //if SelectedItem == null
                    if (isNew) 
                        if (_myNewSimpleItem == "Super")
                        {
                            mySimpleItem = _myNewSimpleItem;
                            mySimpleItems.Add(_myNewSimpleItem);                            
                        }
                }
            }
    
            #endregion
    
            #region cTor
    
            public SimpleVM()
            {
                var ObCol = new ObservableCollection<string>();
    
                ObCol.Add("Max");
                ObCol.Add("Dennis");
                ObCol.Add("Lucas");
    
                mySimpleItems = ObCol;
            }
    
            #endregion
        }
