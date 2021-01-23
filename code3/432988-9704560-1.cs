    public override void OnApplyTemplate()
    {
        var upButton = GetTemplateChild("PART_IncreaseTime") as Button;
        upButton.Click += IncreaseClick;
        
        var downButton = GetTemplateChild("PART_DecreaseTime") as Button;
        downButton.Click += DecreaseClick;
    }
     
    private void IncreaseClick(object sender, RoutedEventArgs e)
    {
        // Here would be a place to see what toggle button is checked 
        // (or which TextBlock last had focus) and increase Hour/Minute
        // based on that info
        Hour += 1;
    }
     
    private void DecreaseClick(object sender, RoutedEventArgs e)
    {
        // Here would be a place to see what toggle button is checked 
        // (or which TextBlock last had focus) and decreaseHour/Minute
        // based on that info
        Hour -= 1;
    }
