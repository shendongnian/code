    private void sh_interface_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("This will close down the whole application. Confirm?", "Close Application", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              foreach (Form f in Application.OpenForms)
                {
                    if (!f.IsDisposed)
                    f.Dispose();
                }
            }
            else
            {
                e.Cancel = true;
                this.Activate();
            }   
        }
