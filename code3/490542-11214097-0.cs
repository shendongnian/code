    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Hide row headers
            dataGridView1.RowHeadersVisible = false;
        }
        // Add new row to grid
        private void btnNew_Click(object sender, EventArgs e)
        {
            // Insert new row as the first row
            dataGridView1.Rows.Insert(0, new DataGridViewRow());
            // Set the current cell to the first cell in the newly added row
            dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
            // Begin edit so that the focus goes straight to the new row
            dataGridView1.BeginEdit(false);
        }
        // "Save" (make the rows non editable)
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {                
                // Set readonly so the user won't be able to edit these rows anymore
                row.ReadOnly = true;
            }
        }
    }
