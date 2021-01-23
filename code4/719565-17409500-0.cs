    for (Node j = head; j != null; j = j.Link )
    {
        // Cast using the as keyword - if the cast fails, parcel will be null, otherwise it will be the casted object
        var parcel = j.Data as Parcel;
        // Check if parcel is null, if not write some info
        if(parcel != null)
        {
            Console.WriteLine(parcel.Id);
            Console.WriteLine(parcel.CustomerName);  // etc
        }
    }
