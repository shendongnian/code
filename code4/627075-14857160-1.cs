       private void linkLabel1_LinkClicked(object sender, 
                                LinkLabelLinkClickedEventArgs e) {
            if (pnlAdvanced.Visible == false) {
                Height += pnlAdvanced.Height;
                pnlAdvanced.Visible = true;
            } else {
                Height -= pnlAdvanced.Height;
                pnlAdvanced.Visible = false;
            }
        }
