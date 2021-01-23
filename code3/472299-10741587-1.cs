    private int myMagicCounter;
    public DerivedClass makeDerived(whatever) // A factory method
    {
      DerivedClass newThing;
      try
      {
        ... do whatever preparation
        newThing = new DerivedClass(ref myMagicCounter, whatever);
      }
      finally
      {
        ... do whatever cleanup
      }
      return newThing;
    }
    BaseClass(ref int magicCounter, whatever...)
    {
      if (magicCounter != myMagicCounter)
        throw new InvalidOperationException();
      myMagicCounter++;
      if (magicCounter != myMagicCounter)
        throw new InvalidOperationException();
    }
