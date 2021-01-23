    //Remove unwanted items
    for (int i = myCustomCollectionObject.Length; i >= 0 ; i--)
    {
    	if(!myCustomCollectionObject[i].IsValid)
    		myCustomCollectionObject.Remove(myCustomCollectionObject[i]);
    }
    
    myCustomCollectionObject.Sort(mycustomerComparer);
