    public void ShowMessage(string title, string message)
    {
       timer1.Enabled = false;
       MessageBox.Show(this,message, title);
       timer1.Enabled = true;
    }
