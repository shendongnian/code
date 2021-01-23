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
    
        public MyDialog() { }
        public MyDialog(IEnumerable<Whatever> items) 
        { 
            Items = items;
        }
    }
