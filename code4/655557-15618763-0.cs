    public void SomeMethod(object o)
    {
       //you absolutely need a sanity check here
       Building c = o as Building;
       if( c == null )
          {
             //throw exception perhaps
          }
    }
