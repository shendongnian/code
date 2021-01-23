    private void btnAdd_Click(object sender, EventArgs e)
    {
        try 
        {
            // Add a row to the DataTable
            DataRow row = hRDataSet.Titles.NewRow();
            row["Title"] = txtAddTitle.Text;
            hRDataSet.Titles.Rows.Add(row);
            // Update the database
            this.titlesTableAdapter.Update(this.hRDataSet);
            // That's it, you're done ;)
        }
        catch (Exception insErr)
        {
            MessageBox.Show(insErr.Message);
        }
    }
