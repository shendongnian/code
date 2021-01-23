    public void SomeMethod()
    {
         if(_disposed)
         {
             throw new ObjectDisposedException();
         }
         else
         {
             // ...
         }
         
    }
