      public MyBox()
        {
            InitializeComponent();
            updateMe();
        }
        public void updateMe()
        {
            listView1.Items.Clear();
            if (MainCode.subRows.Count > 0)
            {
                foreach (KeyValuePair<string, string> element in MainCode.subRows)
                {
                    ListViewItem lvi= new ListViewItem(element.Value);
                    lvi.SubItems.Add(element.Key);
                    listView1.Items.Add(lvi);
                }
            }
        }
        private void btnCreateEditor_Click(object sender, EventArgs e)
        { 
            plainTextEditor editor = new plainTextEditor(this);
            Form1.editorOpen = true;
            editor.Show(this);
        }
