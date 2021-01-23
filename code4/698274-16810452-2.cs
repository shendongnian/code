    protected void Button3_Click(object sender, EventArgs e)
    {
        foreach (string item in myList)
        {
            Label1.Text += item.ToString();
        }
    }
