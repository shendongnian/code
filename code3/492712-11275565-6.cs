    GenClass<string> stringCollection = new GenClass<string>();
    //TODO: Add items
    stringCollection.SomeCondition = s => s.StartsWith("A");
    stringCollection.UsePredicate = true;
    foreach (int index in stringCollection.FilteredIndexes) {
        stringCollection[index] = stringCollection[index] + " starts with 'A'";
    }
