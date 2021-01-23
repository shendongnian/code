    private void imLeft_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
    {
        _wormDirection = Direction.Left;
        ((Image)sender).Source = null;
    }
    private void imLeft_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
        System.Threading.Thread.Sleep(25);
        ((Image)sender).Source = imLeftImageSource;
    }
