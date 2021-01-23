     public delegate void AddItemHandler(object sender, ListObject itemToAdd);
    
        public partial class AddWindow : Window
        {
            public event AddItemHandler AddItem;
            public AddWindow()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                ListObject itemToAdd = new ListObject();
                itemToAdd.ListValue = textBox1.Text;
                AddItem(this, itemToAdd);
            }
        }
