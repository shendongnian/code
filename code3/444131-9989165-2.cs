    public Control TopMostParent
    {
        get
        {
            var parent = Parent;
            while (parent.Parent != null)
            {
                parent = parent.Parent;
            }
            return parent;
        }
    } 
