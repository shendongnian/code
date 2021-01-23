    public MyCustomControl()
    {
        MouseMove += MyCustomControl_MouseMove;
    }
    
    
    void MyCustomControl_MouseMove(object sender, MouseEventArgs e)
    {
       //now you can react to the movement of the mouse.
       //if for example I want to address an element, let's say a rectangle:
    
       var ele = (Rectangle)Template.FindName("myRect",this);
       ele.Fill=myNewBrush;
    
       // provided that we have an element named "myRect" (x:name="myRect") in
       // the generic.xaml style->Control Template-> which corresponds to that name.
    
    }
