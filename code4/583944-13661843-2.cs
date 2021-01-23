    List<Control> visibleList = null;
    protected void FindVisibleControls(Control parent) 
    {
        foreach(Control c in parent.Controls) 
        {
           if (c.Visible)
           {
              visibleList.Add(c);
           }
           
           if (c.HasControls())
              FindVisibleControls(c);
        }
    }
