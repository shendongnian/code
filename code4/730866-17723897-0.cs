    EventManager.RegisterClassHandler(typeof(Button), Button.ClickEvent, new RoutedEventHandler(Button_Click));
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	//Do awesome stuff with the button click
    }
