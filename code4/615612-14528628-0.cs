    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {        
        Plg.Points.Clear(); 
        Plg.Points.Add(new Point(this.ActualWidth / 2 , 0));
        Plg.Points.Add(new Point(2, this.ActualHeight));
        Plg.Points.Add(new Point(this.ActualWidth, this.ActualHeight));         
    }
