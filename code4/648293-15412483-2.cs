      private void button1_Click(object sender, EventArgs e)
            {
                this.Dispose();
                this.Close();
            }
    
        if (MessageBox.Show("Changes have been made..\r\nSave to configuration file (.ini) ?", "Warning",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        button1.PerformClick();
                    }
