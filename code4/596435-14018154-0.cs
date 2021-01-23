    int numberOdRows=int32.Parse(NoRows.Text); //NoRows is the 1st textBlock
    int numberOdColumns=int32.Parse(NoCols.Text); //NoCols is the 2st textBlock
 
    StackPanel _stack0=new StackPanel { orientation = Orientation.Vertical};
    for (int i=1;i<numberOdRows;i++)
    {
        StackPanel _stack1=new StackPanel{ orientation = Orientation.Horizontal};
        for (int j=1;i<numberOdColumns;i++)
        {
             image; //I assume you can call it
            _stack1.Children.Add(image)
        }
        _stack0.Children.Add(_stack1)
    }
    
    //Add _stack0 to your panel
