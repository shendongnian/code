    public ToolStripItemCollection MenuItems
    {
       get { return _Menu.Items; }
       set 
       {
          _Menu.Items.Clear();
          foreach(var elem in value)
          {
             _Menu.Items.Add(elem);
          }
       }
    }
