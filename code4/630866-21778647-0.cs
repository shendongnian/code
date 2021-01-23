    private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnSave.Tag.ToString() == "0")
            {
                DialogResult dlg = MessageBox.Show("Do you want to exit without finished setup connection?", "Form", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlg == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                    this.Dispose();
                    Application.Exit();
                }
            }
            else 
            {
                this.Hide();
            }
        }
