    private void btnApply_Click(object sender, EventArgs e)
    {
        try
        {               
            applyChangesAndCheckRestartService();
        }
        
        // catch service start exceptions
        catch (InvalidOperationException ioex)
        {
            // display message that couldn't start service
        }
        // catch rest
        catch (Exception ex)
        {
            MessageBox.Show("Error loading page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
