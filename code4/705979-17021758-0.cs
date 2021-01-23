    private Form2 form2;
    public Form1()
    {
        form2 = new Form2();
    }
    private void newDocument_ItemClick(object sender, ClickEventArgs e)
    {
        if(!form2.Visible)
        {
            form2.Show();
        }else
        {
            form2.Hide();
        }
    }
