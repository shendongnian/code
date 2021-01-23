    Console.WriteLine("Input a string to create a list:");
    var createListName = Console.ReadLine();
    // As long as they haven't used the string before...
    MyDictionary.Add(createListName, new List<string>());
    Console.WriteLine("Input a string to retrieve a list:");
    var retrieveListName = Console.ReadLine();
    // As long as they input the same string...
    List<string> retrievedList = MyDictionary[retrieveListName];
    
