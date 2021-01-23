    public void MakeMeASandwich()
    {
       try
       {
          MakeCallerASandwich();
       }
       catch(SecurityException ex)
       {
          //It's still best to distinguish between certain exceptions
          // as long as it makes sense to the caller.
          throw new NoIWillNotMakeYouASandwichException(ex);
       }
       catch(Exception ex)
       {
          throw new SorryICantMakeYouASandwichException(ex);
       }
    }
