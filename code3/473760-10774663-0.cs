    (assuming x:Name="myGrid" in markup)
     
    // add rows to grid (it's the same deal for columns too)
     for (int row=0;row < numRows; row++)
     {
     myGrid=RowDefinitions.Add(new RowDefinition());
     }
     
    (I'd be interested to see if there is a slicker way of doing this bit. )
     
    
    // Stick a control in intended location
     
    b = new Button();
     
    myGrid.Children.Add(b);
     Grid.SetRow(b,1); // 2nd row
     Grid.SetColumn(b,3); // 4th column
     Grid.SetColumnSpan(b,2);
     
