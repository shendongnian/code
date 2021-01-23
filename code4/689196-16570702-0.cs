    public static Control FindControlRecursive(Control root, string id)
    {
       if (root.ID == id) 
         return root;
    
       return root.Controls.Cast<Control>()
          .Select(c => FindControlRecursive(c, id))
          .FirstOrDefault(c => c != null);
    }
