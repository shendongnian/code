    private void Form1_Load(object sender, EventArgs e)
        {
            GetICD10();
            FreezeBand(dataGridView1.Columns[0]);   // Client requested to have ICD code column "frozen" by default
            // Cannot seem to select both autosize and allow user to size in designer, so below is the "code around".
            //  Designer has autosize set to displayedcells.
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;   // Turn off autosize
            dataGridView1.AllowUserToResizeRows = true;                                 // Turn on letting user size columns
            dataGridView1.AllowUserToOrderColumns = true;
            // Create tooltip and populate it
            var toolTip1 = new ToolTip { AutoPopDelay = 5000, InitialDelay = 1000, ReshowDelay = 500, ShowAlways = true };
            toolTip1.SetToolTip(tbCode, "Enter an ICD code to search for");
            toolTip1.SetToolTip(tbDescriptionLong, "Enter a description to search for");
        }
