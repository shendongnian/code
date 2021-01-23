    public void Dispose(bool AllResources)
    {
         if(AllResources)
         {
              _context.Dispose();
         }
         //Clean-up other resources
    }
