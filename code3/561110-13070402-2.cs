    DialogResult result = DialogResult.Retry;
    while (result == DialogResult.Retry) {
        try {
            DoProcess();
            break;
        }
        catch (Exception ex) {
            result = MessageBox.Show(ex.ToString(), 
                        "Error Information", 
                        MessageBoxButtons.AbortRetryIgnore,
                        MessageBoxIcon.Exclamation);
            if (result == DialogResult.Abort) throw;
        }
    }
