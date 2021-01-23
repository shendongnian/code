    public void Dispose()
    {
       Dispose(true);
    }
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
         this.Close();
      }
      base.Dispose(disposing);
    }
