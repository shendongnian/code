    foreach (Visit visit in visits)
    {
       if (visit is Delivery)
       {
           Delivery d = (Delivery)visit;
           //delivery specific code here
       }
       else if (visit is Pickup)
       {
           Pickup p = (Pickup) visit;
           //pickup specific code here
       }
       else
       {
           //unknown descendant, panic
       }
    }
