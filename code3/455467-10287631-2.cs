     public Form1()
        {
            InitializeComponent();
        }
        List<string> _items = new List<string>();
        public void LoadListBoxWithItems()
        {
            for (int i = 0; i < 5; i++)
            {
                _items.Add(string.Format("My New Item {0}", i));
            }
            lbItems.DataSource = _items;
            lbItems.Refresh();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
                Form2 form2 = new Form2();
                form2.LoadValues(lbItems.SelectedItem.ToString(), this);
                form2.ShowDialog();
        }
        public string GetCurrentItem()
        {
            return lbItems.SelectedItem.ToString();
        }
        public void UpdateItem(string item, string newitem)
        {
            int index = _items.IndexOf(item);
            _items[index] = newitem;
            lbItems.Refresh();
        }
