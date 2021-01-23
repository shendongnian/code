    void askToSave (Baseform f) {
        if (f.isEditable == true)
        {
            if (MessageBox.Show("To Do Do You Want To Save from MainForm " + f.Text, "Status",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Information) == DialogResult.Yes)
            {
                f.Save();
            }
        }
    }
