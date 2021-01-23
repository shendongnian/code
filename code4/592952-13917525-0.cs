    bool _mousePressed;
    private void OnMouseDown(object sender, MouseEventArgs e)
    {
        _mousePressed = true;
    }
    private void OnMouseMove(object sender, MouseEventArgs e)
    {
        if (_mousePressed)
        {
            //Operate
        }
    }
    private void OnMouseUp(object sender, MouseEventArgs e)
    {
        _mousePressed = false;
    }
