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
        /// <summary>
        /// Button Click to update / edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
                Form2 form2 = new Form2();
                form2.LoadValues(lbItems.SelectedItem.ToString(), this);
                form2.ShowDialog();
        }
        /// <summary>
        /// Get the current item in the list box
        /// </summary>
        /// <returns></returns>
        public string GetCurrentItem()
        {
            return lbItems.SelectedItem.ToString();
        }
        /// <summary>
        /// Update the backing property
        /// </summary>
        /// <param name="item"></param>
        /// <param name="newitem"></param>
        public void UpdateItem(string item, string newitem)
        {
            int index = _items.IndexOf(item);
            _items[index] = newitem;
            lbItems.Refresh();
        }
