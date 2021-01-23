    private int? x1;
    private void MyImageControl_MouseClick(object sender, MouseEventArgs e)
    {
        if (x1.HasValue)
        {
            MessageBox.Show("Difference of " + Math.Abs(e.X - x1.Value).ToString());
            x1 = null;
        }
        else
        {
            x1 = e.X;
        }
    }
