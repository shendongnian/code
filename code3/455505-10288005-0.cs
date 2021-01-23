    List<Cow> listOfCows = GetListOfCows();
    
    listOfAnimals = listOfCows;
    //After some lines of code
    List<Tiger> listOfTiger = GetListOfTigers();
    listOfAnimals.Add(listOfTiger); //Epic fail.
