    Void Method()
    {
     string text = File.ReadAllText(@"c:\text.txt");
    
     string  NewText="This is new Text " + DateTime.Now.TimeOfDay;
    
     File.WriteAllText(@"c:\text.txt", NewText + Environment.NewLine  + text);
    
    }
