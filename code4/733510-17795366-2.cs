    private void Window_ContentRendered(object sender, EventArgs e)
    {
        this.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
        this.Arrange(new Rect(0, 0, 0, 0));
        MessageBox.Show(this.Height.ToString()); 
        MessageBox.Show(this.ActualHeight.ToString());
    }
