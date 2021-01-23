    bool CompetitorAlreadyExist()
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.ColumnIndex == 0) // set your column index
                {
                    // do your stuff here… i.e., compare `textStN.Text` with all values
                    // in column start # and return true or false 
                }
            }
        }
    }
    private void buttonSave_Click(object sender, EventArgs e)
    {
        if (CheckFiledIsEmpty() && CompetitorAlreadyExist())
        {
            string column1 = textStN.Text;
            string column2 = textN.Text;
            string column3 = textSN.Text;
            string column4 = textC.Text;
            string column5 = textYB.Text;                    
            string[] row = { column1, column2, column3, column4, column5 };
            dataGridView1.Rows.Add(row);
            textStN.Text = "";
            textN.Text = "";
            textSN.Text = "";
            textC.Text = "";
            textYB.Text = "";
        }
        else
        {
            MessageBox.Show("Input all information about competitor!");
        }
    }
