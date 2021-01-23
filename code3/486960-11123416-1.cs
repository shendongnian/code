    public class WrapperBase<T>: IWrapper
    {
        protected T obj;
        protected internal WrapperBase(IWrapper Owner)
        {
            SetOwner(Owner);
        }
        protected WrapperBase() { }
        CultureSwitcher cultswitch;
        public CultureSwitcher CultureSwitcher
        {
            get
            {
                if (cultswitch == null)
                {
                    if (owner != null) return owner.CultureSwitcher;
                    cultswitch = new CultureSwitcher();
                }
                return cultswitch;
            }
        }
        public T Object { get { return obj; } internal set { obj = value; } }
        //public abstract void Save();
        public bool IsDisposed { get { return disposed; } }
        bool disposed;
        public void Dispose()
        {
            Dispose(false);
        }
        void Dispose(bool fromfinalize)
        {
            if (disposed) return;
            disposed = true;
            if (!fromfinalize)
                GC.SuppressFinalize(this);
            
            CultureSwitcher.Try(OnDisposing);
            if (obj != null)
            {
                while (Marshal.ReleaseComObject(obj) > 0) { }
                obj = default(T);
            }
            if (cultswitch != null)
            {
                cultswitch.Dispose();
                cultswitch = null;
            }
            SetOwner(null);
        }
        protected virtual void OnDisposing()
        {
            if (children != null)
            {
                foreach (var c in children)
                    c.Dispose();
                children = null;
            }
        }
        ~WrapperBase()
        {
            Dispose(true);
        }
        List<IWrapper> children;
        IWrapper owner;
        public IWrapper Owner
        {
            get { return owner; }
        }
        protected void SetOwner(IWrapper Owner)
        {
            if (Owner == owner) return;
            if (owner != null)
            {
                owner.DeRegister(this);
            }
            owner = Owner;
            if (owner != null)
            {
                owner.Register(this);
            }
        }
        public void Register(IWrapper Child)
        {
            if (disposed)
                throw new ObjectDisposedException("Cannot register children after disposing");
            if (children == null)
                children = new List<IWrapper>();
            children.Add(Child);
        }
        public void DeRegister(IWrapper Child)
        {
            if (disposed) return;
            children.Remove(Child);
        }
        protected IEnumerable<IWrapper> GetChildren()
        {
            return children;
        }
    }
