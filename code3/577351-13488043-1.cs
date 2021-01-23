     TextBox tb;
    static int i = 0;
    protected void addnewtext_Click(object sender, EventArgs e)
    {
            i++;
        for(j=0;j<=i;j++)
        {
        tb = new TextBox();
        tb.ID = j.ToString();
        PlaceHolder1.Controls.Add(tb);
        }
    }
