    public IMyControl ActiveControl 
    {
      get 
      {
        return (isSomeCondition)? myFoo : myBar; 
      }
    }
