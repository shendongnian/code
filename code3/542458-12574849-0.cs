    public Form1()
    {
        InitializeComponent();
    
        // Create a DataGridView with 5 Columns
        // Each column is going to sized at 100 pixels wide which is default
        // Once filled, we will resize the form to fit the control
        DataGridView dataGridView1 = new DataGridView();
        for (int i = 0; i < 5; i++)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            dataGridView1.Columns.Add(col);
        }
        dataGridView1.Location = new Point(0, 0);
    
        // Add the DataGridView to the form
        this.Controls.Add(dataGridView1);
        // Step 2:
        // Figure out the width of the DataGridView columns
        int width = 0;
        foreach (DataGridViewColumn col in dataGridView1.Columns)
            width += col.Width;
        width += dataGridView1.RowHeadersWidth;
        // Step 3:
        // Change the width of the DataGridView to match the column widths
        // I add 2 pixels to account for the control's borders
        dataGridView1.Width = width + 2;
        // Step 4:
        // Now make the form's width equal to the conbtrol's width
        // I add 16 to account for the form's boarders
        this.Width = dataGridView1.Width + 16;
    }
