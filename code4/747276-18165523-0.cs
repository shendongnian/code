        // Anchor
    
        rootFamily.Children.ForEach(childFamily => 
        {
            if (childFamily.Name.Contains(search))
            {
               // Your logic here
               return;
            }
            SearchForChildren(childFamily);
        });
        // Recursion
    
        public void SearchForChildren(Family childFamily)
        {
            childFamily.Children.ForEach(_childFamily => 
            {
                if (_childFamily.Name.Contains(search))
                {
                   // Your logic here
                   return;
                }
                SearchForChildren(_childFamily);
            });
        }
    
    
    
         
