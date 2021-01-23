    public override void OnKeyDown(MyCanvas dc, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            _line = null;
            dc.CurrentTool = ToolType.Pointer;
            dc.Cursor = Cursors.Arrow;
            dc.ReleaseMouseCapture();
    
        }
    }
