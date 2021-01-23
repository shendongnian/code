    object[] items = al.ToArray();
    
    bool result = items.Any(c => c is TextBox);// implement whatever logic you want here
    //bool result = items.Any(c => c.Name == "blabla");//another logic sample
    
    if ( result )
    {
       al.Add(ctrl);
       Session["MyControls"] = al;
    }
