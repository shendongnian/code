    Visit v = GetVisit() //or whatever your method is
    if(v.GetType() == typeof(Delivery))
    {
        Delivery d = v as Delivery;
    }
    else //Must be Pickup
    {
        Pickup p = v as Pickup;
    }
