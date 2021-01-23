    Form2 frm = new Form2 ();
    //you will need to call frm.Show() somewhere to display form2
    private void Button1_Click(object sender, EventArgs e)
    {
        Form2.tabControl1.SelectedIndex = 0;
    }
    private void Button2_Click(object sender, EventArgs e)
    {
        Form2.tabControl2.SelectedIndex = 1;
    }
    
