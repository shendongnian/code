    public partial class A
    {
        public IQueryable<B> Bs {
            get { return this.ABs.AsQueryable().Select(ab => ab.B).Distinct(); }
        }
    }
