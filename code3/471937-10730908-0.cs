    private void txtBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e) 
    {
        TextBox txtbx = sender as TextBox;
        if (txtbx != null)
        {
            if (txtbx.SelectionLength > 0)
            {
                string seltxt = txtbx.SelectedText;
                //Do Work Here with 'seltxt' variable!
            }
        }
    }
