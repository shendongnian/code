    private void saveButton_Click(object sender, EventArgs e)
    {
        try
        {
            ... call BLL to save data
        }
        catch(Exception ex)
        {
            MessageBox.Show("Failed to save data");
        }
    }
