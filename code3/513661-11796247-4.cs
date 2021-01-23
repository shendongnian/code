    public MyClass : Base
    {
      Stream _forExample;
      public override void Dispose(bool disposing)
      {
        if(disposing)
        {
          _forExample.Dispose();
        }
        base.Dispose(disposing);
      }
    }
