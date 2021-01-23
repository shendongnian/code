    private Dictionary<Control, Action> _controlsToActions = new Dictionary<Control, Action>() {
        { control1, method1 } // one for each control/handler pair
    };
    
    private void UIObject_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
          _controlsToActions[(Control)sender]();
        }
    }
    
    private void UIObject_DoubleClick(object sender, KeyEventArgs e)
    {
        _controlsToActions[(Control)sender]();
    }
