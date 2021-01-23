    public static Parent FindParent<Parent>(DependencyObject child)
                where Parent : DependencyObject
    {
       DependencyObject parentObject = child;
    
       //We are not dealing with Visual, so either we need to fnd parent or
       //get Visual to get parent from Parent Heirarchy.
       while (!((parentObject is System.Windows.Media.Visual)
               || (parentObject is System.Windows.Media.Media3D.Visual3D)))
       {
           if (parentObject is Parent || parentObject == null)
           {
               return parentObject as Parent;
           }
           else
           {
              parentObject = (parentObject as FrameworkContentElement).Parent;
           }
        }
    
        //We have not found parent yet , and we have now visual to work with.
        parentObject = VisualTreeHelper.GetParent(parentObject);
    
        //check if the parent matches the type we're looking for
        if (parentObject is Parent || parentObject == null)
        {
           return parentObject as Parent;
        }
        else
        {
            //use recursion to proceed with next level
            return FindParent<Parent>(parentObject);
        }
    }
