    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            for (int i = 1; i < listView1.Items.Count; i++)
            {
                dataGridView1.Rows.Add();
            }
        }
        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Decide which column corresponds to the one clicked
            switch (e.ColumnIndex)
            {
                case 0:
                    FillColumn(listView2, 0, e.ColumnIndex);
                    break;
                case 1:
                    FillColumn(listView1, 1, e.ColumnIndex);
                    break;
                case 2:
                    FillColumn(listView2, 1, e.ColumnIndex);
                    break;
                case 3:
                    FillColumn(listView1, 0, e.ColumnIndex);
                    break;
                case 4:
                    FillColumn(listView1, 2, e.ColumnIndex);
                    break;
            }
        }
        //Take the corresponding listview, the listview column, and the dgv column
        //and populate the dgv with the listview data
        private void FillColumn(ListView lv, int lvcolumn, int dgvcolumn)
        {
            lv.Visible = true;            
            foreach (ListViewItem lvi in lv.Items)
            {
                dataGridView1.Rows[lvi.Index].Cells[dgvcolumn].Value = lvi.SubItems[lvcolumn].Text;
            }
        }
    }
