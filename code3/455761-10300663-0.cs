    public partial class Form1 : Form
    {
        BindingSource bs;
        DataTable dt;    public Form1()
        {
            InitializeComponent();
    
            BindingList<BindingClass> data = new BindingList<BindingClass>
                { 
                    new BindingClass{ Name = "one" }, 
                    new BindingClass { Name = "two"} 
                };
    
            dataGridView1.DataSource = data;
            dataGridView1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
    
        }
    
        void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index != e.RowIndex & !row.IsNewRow)
                {
                    if (row.Cells[0].Value.ToString() == e.FormattedValue.ToString())
                    {
                        dataGridView1.Rows[e.RowIndex].ErrorText =
                            "Duplicate value not allowed";                    
    
                        e.Cancel = true;
                        return;
                    }
                }
            }
            dataGridView1.Rows[e.RowIndex].ErrorText = string.Empty;
        }
    
    } 
    
        public class BindingClass
        {
            public string Name { get; set; }
        }
    
    }
