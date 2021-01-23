    protected void ShowResult(object sender, EventArgs e)
    {
     foreach(long item in ViewStateList)
        {
           Label.Text += item.ToString();
        }
    }
