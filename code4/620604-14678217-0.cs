    private void Form1_MouseClick(object sender, MouseEventArgs e)
    {
        var c = this.GetChildAtPoint(e.Location);
        this.InvokeOnClick(c, e);
    }
