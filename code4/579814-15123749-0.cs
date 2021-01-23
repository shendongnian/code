    public partial class EntityContainer : IUnitOfWork {
        public void Save() {
            this.SaveChanges();
        }
        void IDisposable.Dispose() {
            base.Dispose();
        }
    }
