     public partial class main : Form
        {
            public main()
            {
                InitializeComponent();
                Get_Frm2_Data();
            }
            private void Get_Frm2_Data()
            {
                Add_Order frm2 = new Add_Order();
                frm2.ShowDialog();
                Info lst_data= frm2.Get_Data();
                ListViewItem item = new ListViewItem();
                item.Text = lst._textBox3;
                item.SubItems.Add(lst._label6);
                item.SubItems.Add(lst._textBox2);
                item.SubItems.Add(lst._textBox1);
                mainform.listView2.Items.Add(item);
            }
        }
