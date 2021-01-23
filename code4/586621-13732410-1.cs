    public void MouseMoved(object sender, MouseEventArgs e)
    {
        labelMousePosition.Text=String.Format("x={0}  y={1}", e.X, e.Y);
        if (e.Clicks>0) LogWrite("MouseButton     - " + e.Button.ToString());
    }
