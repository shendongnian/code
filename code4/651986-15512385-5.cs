    //Saving
    byte[,] TestArray = new int[1000,1000];
    //...Fill array
    Serialize(TestArray);
        
    //Loading
    byte[,] TestArray = Deserialize();
        
        
