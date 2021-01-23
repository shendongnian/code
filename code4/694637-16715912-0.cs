    string s = "Potato";
    int i;
    if(int.TryParse(s, out i))
    {
        //This code is only executed if "s" was parsed succesfully.
        aCollectionOfInts.Add(i);
    }
