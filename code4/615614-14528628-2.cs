    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    {        
        Plg.Points.Clear(); 
        Plg.Points.Add(new Point(myGrid.ActualWidth / 2 , 0));
        Plg.Points.Add(new Point(2, myGrid.ActualHeight));
        Plg.Points.Add(new Point(myGrid.ActualWidth, this.ActualHeight));         
    }
