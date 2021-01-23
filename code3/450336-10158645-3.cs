    public abstract class NinjectApiController : ApiController, INotifyWhenDisposed
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.IsDisposed = true;
            this.Disposed(this, EventArgs.Empty);
        }
        public bool IsDisposed
        {
            get;
            private set;
        }
        public event EventHandler Disposed;
    }
