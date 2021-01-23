    private void btn_Click(object sender, EventArgs e)
            {
                MessageBox.Show("Test")
            }
    
    private void txb_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)13)
                {
                    btn_Click(sender, e);
                }
