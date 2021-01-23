    List<string> modules = new List<string>();
            
    foreach(ListItem s in chk_modules.Items)
    {
        if (s.Selected)
        {
             modules.Add(s.Value);
        }
    }
