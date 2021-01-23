    IEnumerable myCollection;
    string discriminator = Console.ReadLine();
    if (discriminator == "string")
    {
       myCollection = new List<string>{"One", "Two", "Three", "Four"};
    }
    else 
    {
       myCollection =  new int[]{1, 2, 3, 4};
    }
    //what should be the type of the elements variable
    var elements = myCollection.ToArray();
    
