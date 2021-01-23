    protected void btnTest_Click(object sender, EventArgs e)
    {
        Button b = sender as Button;
        if ((b != null) && (b.Name == "btnTest"))
        {
             b.Text = "yay";
        }
    }
