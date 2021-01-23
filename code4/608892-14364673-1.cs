    Getters = new Func<T, string>[numProperties];
    Setters = new Action<T, string>[numProperties];
    for (int i = 0; i< numProperties; i++)
    {
      int ii = i;  // Important--ensure closure is inside loop
      Getters[ii] = (T it) => FindSetAndRunGetter(ii, it);
      Setters[ii] = (T it, string st) => FindSetAndRunSetter(ii, it, st);
    }
