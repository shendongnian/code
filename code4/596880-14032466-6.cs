    public class CustomControl:Border
    {
    	Label theLabel = new Label();
    	TextBox theTextbox = new TextBox();
    
    	public CustomControl()
    	{ 
    	StackPanel sp = new StackPanel();
    	this.Child = sp;
    	sp.Children.Add(theLabel);
    	sp.Children.Add(new TextBox(theTextbox));
    
    	theTextbox.GotFocus = tb_GF;
    	} 
    
    
    	void tb_GF(object sender, GotFocusEventArgs e)
    	{
    		theLabel.Background = Brushes.Yellow;
    	}
