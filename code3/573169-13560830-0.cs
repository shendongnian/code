    I understand your problem. You want to click on pushpin and on that click event, you want to open a new page. Write the above code in PhoneApplicationPage_Loaded(). Here is the code..
    
    private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
    {
    map1.Center = new GeoCoordinate(21.7679, 78.8718); //coordinates for location of India
    map1.ZoomLevel = 5;
    
    Pushpin puspin1 = new Pushpin();
    puspin1.Location = new GeoCoordinate(21.7679, 78.8718);
    puspin1.Background = new SolidColorBrush(Colors.Blue);
    puspin1.MouseLeftButtonUp += new MouseButtonEventHandler(puspin1_MouseLeftButtonUp);
    map1.Children.Add(puspin1);
    
    }
    
    void puspin1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
    	this.NavigationService.Navigate(new Uri("YourWindowName", UriKind.Relative));
    }
