    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.originals != null)
        {
          foreach (ImageList.Original original in (IEnumerable) this.originals)
          {
            if ((original.options & ImageList.OriginalOptions.OwnsImage) != ImageList.OriginalOptions.Default)
              ((IDisposable) original.image).Dispose();
          }
        }
        this.DestroyHandle();
      }
      base.Dispose(disposing);
    }
