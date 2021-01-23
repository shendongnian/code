    private void Form1_Load(object sender, EventArgs e)
        {
            //  Designer has autosize set to displayedcells.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;   // Turn off autosize
            dataGridView1.AllowUserToResizeRows = true;                                 // Turn on letting user size columns
            dataGridView1.AllowUserToOrderColumns = true;
        }
