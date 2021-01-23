    public delegate void MouseMove(object sender, MouseEventArgs e, Control control, Control container, Direction direction);
    public static event MouseMove OnMouseMove;
    
    public static void FireOnMouseMove(object sender, MouseEventArgs e) 
    { 
        if (OnMouseMove != null) 
            OnMouseMove(this, e, sender as Control, aContainer, aDirection); 
    }
