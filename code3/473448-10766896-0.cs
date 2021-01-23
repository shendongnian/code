    private void Button1_Click_ShowChildForm(args..)
    {
        Form2 frm2 = new Form2();
        frm2.Show();
        frm2.GetInstance(this);
    }
    
    public void PassBack(string var)
    {
        TextBox1.Text = var;
    }
