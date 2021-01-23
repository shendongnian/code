    // method to convert from 'old' WinForms Point to 'new' WPF Point structure:
    public System.Windows.Point ConvertToPoint(System.Drawing.Point p)
    {
        return new System.Windows.Point(p.X,p.Y);
    }
    // some locals you will need:
    bool mid = false; // Mouse Is Down
    int x=0, y=0;
    // Mouse down event
    private void MainForm_MouseDown(object sender, MouseButtonEventArgs e)
    {
       mid=true;
       Point p =  e.GetPosition(this);
       x = (int)p.X; 
       y = (int)p.Y;
    }
    // Mouse move event
    private void MainForm_MouseMove(object sender, MouseButtonEventArgs e)
    {
       if(mid)
       {
            int x1 = e.GetPosition(this).X;
            int y1 = e.GetPosition(this).Y;
            
            Left = x1-x;
            Top = y1-y;
       }
    }
    // Mouse up event
    private void MainForm_MouseUp(object sender, MouseButtonEventArgs e)
    {
        mid = false;
    }
