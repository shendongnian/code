    [NonAction]
    public new void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
