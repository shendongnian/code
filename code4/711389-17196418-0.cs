    List<string> names; // starts off as null
    // the following line would cause a null reference exception
    // names.Add("names");
    names = new List<string>(); // create an instance
    // now you can safely work with it
    names.Add("names");
    // of course, you can also initialize when you declare
    List<string> names2 = new List<string>();
    names2.Add("names2");
