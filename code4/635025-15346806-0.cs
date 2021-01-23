    public partial class HistForm : Form
    {
        DataSet data;
        public HistForm(DataSet ds)
        {
            data = ds;
            InitializeComponent();
            FillDataGrid();            
        }
        private void FillDataGrid()
        {
            dataGridView1.DataSource = data.Tables[0];
        }
    }
