    Button myButton;
    void MakeButtonQ() 
    { 
        Button b2 = new Button(); 
        b2.Content = Class1.Question; 
        b2.Height = 150; 
        b2.Width = 230; 
        b2.Background = new SolidColorBrush(Colors.White); 
        b2.Foreground = new SolidColorBrush(Colors.Black); 
        stackPanel1.Children.Add(b2); 
        myButton = b2
    } 
    void ChangeButtonsContent()
    {
        myButton.Content = "Content changed";
    }
