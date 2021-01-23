    //If you are creating stack panel in code you need to uncomment next line
    //NameScope.SetNameScope(SomeStackPanel, new NameScope());
    for(i=0; i<5; i++)
    {
        MyUserControl control = new MyUserControl ();
        
        control.Name = "name" + i;
        
        SomeStackPanel.RegisterName(control.Name, control);
        SomeStackPanel.Children.Add(control);
    }
