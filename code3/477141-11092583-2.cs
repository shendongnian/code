    private void OnHostControlSizeChanged(object sender, EventArgs e)
    {
        var wpfHostControl = sender as WpfHostControl;
        if (wpfHostControl != null)
        {
            System.Windows.Forms.SendKeys.Send("{ESC}");
            _samplePane.Height = HeightConstant;
        }
    }
