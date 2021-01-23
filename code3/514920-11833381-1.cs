    class MyDialog : Form
    {
        public IEnumerable<Whatever> Items
        {
            get { return _items; }
            set 
            { 
                _items = value; 
                someComboBox.Items = value; 
            }
        }
    
        public MyDialog(IEnumerable<Whatever> items) 
        { 
            InitializeComponent();
            Items = items;
        }
    }
