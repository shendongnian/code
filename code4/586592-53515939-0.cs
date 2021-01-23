    var aList = Enumerable.Range(1, 100).ToList(); //a given list
    var size = 9; //the wanted batch size
    //number of batches are: (aList.Count() + size - 1) / size;
    
    var batches = Enumerable.Range(0, (aList.Count() + size - 1) / size).Select(i => aList.GetRange( i * size, Math.Min(size, aList.Count() - i * size)));
    
    Assert.True(batches.Count() == 12);
    Assert.AreEqual(batches.ToList().ElementAt(0), new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
    Assert.AreEqual(batches.ToList().ElementAt(1), new List<int>() { 10, 11, 12, 13, 14, 15, 16, 17, 18 });
    Assert.AreEqual(batches.ToList().ElementAt(11), new List<int>() { 100 });
