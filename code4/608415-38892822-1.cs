    if (Keys.Escape.ToString() == "Escape")
                gvExpireDate.Visible = false;
    private void DatagridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            //MessageBox.Show(Keys.Escape.ToString());
            if (Keys.Escape.ToString() == "Escape")
                gvExpireDate.Visible = false;
            //if(e.KeyChar == Keys.Escape)
        }
