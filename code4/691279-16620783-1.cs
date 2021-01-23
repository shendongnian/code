    for (int i = 0; i < gems.Count; i++)
    {
       // gives you the element on top of the stack
       Crystal crystal = crystals.Peek();
                    
       // do other stuff here
    
       if (crystal.BoundingCircle.Equals(Player.BoundingRectangle))
       {
           // removes the element on top of the stack (the last one entered)
           crystals.Pop();
    
           // do even more stuff here ...
       }
    }
