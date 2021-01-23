    private void dataGridView1_Scroll(object sender, ScrollEventArgs ex)
    {
        try
        {
             dataGridView1.Focus();
        }
        catch (Exception ex)
        {
             MessageBox.Show(ex.Message);
        }
    }
