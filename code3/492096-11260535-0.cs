    private Rectangle _myRectangle;
    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        if (this._myRectangle.Contains(e.Location))
        {
            
        }
    }
