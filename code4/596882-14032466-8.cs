    public class CustomControl:Border
    {
    	Label theLabel = new Label();
    	TextBox theTextbox = new TextBox();
    
    	public CustomControl()
    	{ 
    	StackPanel sp = new StackPanel();
    	this.Child = sp;
    	sp.Children.Add(theLabel);
    	sp.Children.Add(theTextbox );
    
    	theTextbox.GotFocus = new RoutedEventHandler(tb_GotFocus);;
    	} 
    
    
    	void tb_GotFocus(object sender, RoutedEventArgs e)
    	{
    		theLabel.Background = Brushes.Yellow;
    	}
    }
