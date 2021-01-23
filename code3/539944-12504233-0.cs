    object[] items = al.ToArray();
    
    int result = items.Where(c => c is TextBox).Count();// implement whatever logic you want here
    //int result = items.Where(c => c.Name == "blabla").Count();//another logic sample
    
    if ( result == 0 )
    {
       al.Add(ctrl);
       Session["MyControls"] = al;
    }
