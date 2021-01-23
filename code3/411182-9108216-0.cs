    namespace Sorter
    {
        using System;
        using System.ComponentModel;
        using System.Windows.Forms;
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                this.dataGridView1.Rows.Add("Abc", 5);
                this.dataGridView1.Rows.Add("Def", 8);
                this.dataGridView1.Rows.Add("Ghi", 3);
                this.dataGridView1.Sort(this.dataGridView1.Columns[1], 
                                        ListSortDirection.Ascending);
            }
        }
    }
