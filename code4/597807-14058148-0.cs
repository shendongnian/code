    public override void Close()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
