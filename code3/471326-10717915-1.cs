    public override void CalcV(IV iv, int index)
    {
      initializations
      otherOperations
      for (int i=0; i < NUM; ++i)
      {
        SomeOtherOperations
        double v = index == -1 ? GetV(a, b, c) : GetV(a,b,c, index);
        SomeOtherOperationsUsing_v
      }
      restOfOperations
    }
