    frmRegisterNew newReg = new frmRegisterNew();    
    newReg.FormClosed += (s, o) =>
        {
            if (newReg.DialogResult == DialogResult.OK)
            {
                MessageBox.Show ("So Far So Good");
            }
        };
    newReg.Show();
    
