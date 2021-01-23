    Getters = new Func<string>[numProperties];
    Setters = new Action<string>[numProperties];
    for (int i = 0; i< numProperties; i++)
    {
      int ii = i;  // Important--ensure closure is inside loop
      Getters[ii] = () => FindSetAndRunGetter(ii);
      Setters[ii] = (string st) => FindSetAndRunSetter(ii, st);
    }
