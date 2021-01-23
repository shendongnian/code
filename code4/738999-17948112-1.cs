    StackPanel sp = new StackPane();
    Image im1 = new Image();
    TextBlock tb = new TextBlock();
    
    //...Put your sizing and editing of objects here...
    
    sp.orientation = System.Windows.Controls.Orientation.Horizontal;
            
    
    sp.add(im1);
    sp.add(tb);
    
    ListOfStuff.Items.Add(sp);
