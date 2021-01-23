    private void mnulogout_Click(object sender, EventArgs e)
            {
                DialogResult dialogresult=MessageBox.Show("Do You Want To LogOut?","LogOut",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogresult == DialogResult.Yes)
                {                    
                    loginPanel.Visible = true;
                    OtherPanels.Visible = false;
                }
            }
