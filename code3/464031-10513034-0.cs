    private void DisplayRow()
    {
        // Check that we can retrieve the given row
        if (myDataTable.Rows.Count == 0)
            return; // nothing to display
        if (rowIndex >= myDataTable.Rows.Count)
            return; // the index is out of range
        // If we get this far then we can retrieve the data
        try
        {
            DataRow row = myDataTable.Rows[m_rowPosition];//<- here you using index which value is changed on button click
            textBox1.Text = row["FilePath"].ToString();
            textBox2.Text = row["Subject"].ToString();
            textBox3.Text = row["Title"].ToString();
            textBox4.Text = row["Keywords"].ToString();
            textBox5.Text = row["MediaType"].ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error in DisplayRow : \r\n" + ex.Message);
        }
    }
