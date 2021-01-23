        try {
            if (!ApplyChangesForSettings())
               return;
        }
        catch (Exception ex) {
            MessageBox.Show("Error loading page.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        if (svrPortNo != tbSvrPortNo.Text) {      
            try {         
                CommonCodeClass.CheckToRestartService();
            }
            catch (Exception ex) {
                MessageBox.Show("Unable to restart services.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
