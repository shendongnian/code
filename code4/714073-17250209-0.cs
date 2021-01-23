    protected override void Dispose(bool disposing)
    {
        if (disposing) {
             var backgroundImage = this.BackgroundImage;
             this.BackgroundImage = null;
             backgroundImage.Dispose();
        }
        base.Dispose(disposing);
    }
