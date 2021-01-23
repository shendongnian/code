    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                // TODO: This line of code loads data into the 'nORTHWNDDataSet.Employees' table. You can move, or remove it, as needed.
                this.employeesTableAdapter.Fill(this.nORTHWNDDataSet.Employees);
    
            }
    
            private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                var dataIndexNo = dataGridView1.Rows[e.RowIndex].Index.ToString();
                string cellValue = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
    
                MessageBox.Show("The row index = " + dataIndexNo.ToString() + " and the row data in second column is: "
                    + cellValue.ToString());
            }
        }
    }
