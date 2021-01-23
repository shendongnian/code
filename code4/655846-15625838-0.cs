	public partial class HealthTrackerContext: IDisposable {
		protected virtual void Dispose(bool disposing) {
			lock(thisLock)
				if(!disposed) {
					if(disposing) {
						// release your resource 
						// and set the referencing variables with null 
						this.disposed=true;
					}
				}
		}
		public void Dispose() {
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		~HealthTrackerContext() {
			this.Dispose(false);
		}
		object thisLock=new object();
		bool disposed;
	}
