    private const int PaneHeight = 52;
    private void OnHostControlSizeChanged(object sender, EventArgs e)
    {
        if (_samplePane != null && _samplePane.Height != PaneHeight)
        {
            System.Windows.Forms.SendKeys.Send("{ESC}");
            _samplePane.Height = PaneHeight;
        }
    }
