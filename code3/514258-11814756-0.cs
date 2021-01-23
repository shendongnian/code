        //this is in form1
        private void bufferedListView1_DoubleClick(object sender, EventArgs e)
        {
            form2 obj = new form2
                            {
                                Name = o.bufferedListView1.SelectedItems[0].SubItems[0].Text,
                                No = o.bufferedListView1.SelectedItems[0].SubItems[1].Text,
                            };
            obj.ShowDialog();
        }
        //in form2
        public String Name;
        public String No;
        Form1 o = new Form1();
        private void form2_Load(object sender, EventArgs e)
        {
            txt_editname.Text = Name;
            txt_editno.Text = No;
        }
