    protected override void Dispose(bool disposing)
    {
       if(disposing)
       {
            _fooRepository.Dispose();
       }
       base.Dispose(disposing);
    }
