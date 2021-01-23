    namespace gridview_row_add
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataGridViewTextBoxColumn columntype = new DataGridViewTextBoxColumn();
                columntype.HeaderText = "Type";
                columntype.Width = 80;
                dataGridView1.Columns.Add(columntype);
                DataGridViewTextBoxColumn columnparameters = new DataGridViewTextBoxColumn();
                columnparameters.HeaderText = "Parameters";
                columnparameters.Width = 320;
                dataGridView1.Columns.Add(columnparameters);
                DataGridViewTextBoxColumn columndisplay = new DataGridViewTextBoxColumn();
                columndisplay.HeaderText = "Display";
                columndisplay.Width = 150;
                dataGridView1.Columns.Add(columndisplay);
                DataGridViewTextBoxColumn enumuration = new DataGridViewTextBoxColumn();
                enumuration.HeaderText = "Format";
                enumuration.Width = 90;
                dataGridView1.Columns.Add(enumuration);
                dataGridView1.AllowUserToAddRows = false;//please add this if u don't want to add exta rows or else make it true.          
            }
            private void button1_Click(object sender, EventArgs e)
            {
                dataGridView1.Rows.Add();//here on each click the new row will be added.
                int rowcount = dataGridView1.Rows.Count;
                dataGridView1.Rows[rowcount - 1].Cells[0].Value = "data" + rowcount.ToString();
                dataGridView1.Rows[rowcount-1].Cells[1].Value = "field";
                dataGridView1.Rows[rowcount-1].Cells[2].Value = "xyzzz";
                dataGridView1.Rows[rowcount-1].Cells[3].Value = "hts";
                rowcount++;                     
            }
        }
    }
