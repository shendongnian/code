    var elementCount = myList.Count();
    for (int i = 0; i < elementCount - 1; ++i)
    {
      var iElement = myList.ElementAt(i);
      for (int j = i+1; j < elementCount; ++j)
      {
        DoMyStuff(iElement, myList.ElementAt(j));
      }
    }
