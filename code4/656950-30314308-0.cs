    private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
    {
        try
        {
            this.yourSqlAdapter.FillBy1(this.yourDatabaseDataSet.prestaties, ((int)(System.Convert.ChangeType(testToolStripTextBox.Text, typeof(int)))));
        }
        catch (System.Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.Message);
        }
    }
