    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace DataGridViewTest
    {
        public partial class DataGridViewForm : Form
        {
            private List<string> dataSource;
            public DataGridViewForm()
            {
                InitializeComponent();
                // Enable VirtualMode for dataGridView1
                dataGridView1.VirtualMode = true;
                // Wire CellValueNeeded event handler
                dataGridView1.CellValueNeeded += DataGridView1_CellValueNeeded;
                // Wire Scroll event handler
                dataGridView1.Scroll += DataGridView1_Scroll;
                // Wire form Shown event handler
                this.Shown += DataGridViewForm_Shown;
            }
            private void DataGridViewForm_Shown(object sender, System.EventArgs e)
            {
                // Populate dataGridView1 here to avoid perception of a long form startup time
                populateDataGridView();
                // Resize columns after the form is initialized and displayed on screen,
                // otherwise calling this method won't actually have an effect on column sizes
                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            }
            private void DataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
            {
                // Set the triggering cell's value to the corresponding value from dataSource
                e.Value = dataSource[e.RowIndex];
            }
            private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
            {
                // Resize columns again, but only if a vertical scroll just happened
                if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                {
                    dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
                }
            }
            private void populateDataGridView()
            {
                fetchIntoDataSource();
                associateDataSourceToDataGridView();
            }
            private void fetchIntoDataSource()
            {
                dataSource = new List<string>();
                // Insert a test string into dataSource many times
                for (int i = 0; i < 1000; i++)
                {
                    dataSource.Add("test string");
                }
            }
            private void associateDataSourceToDataGridView()
            {
                // Synchronize dataGridView1.RowCount to dataSource.Count
                // This is necessary for the CellValueNeeded event to fire
                dataGridView1.RowCount = dataSource.Count;
            }
        }
    }
