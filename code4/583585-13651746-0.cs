      abstract class A
      {
        // Avoid defining custom delegate at all because there is a lot of 
        // build-in events for every case, like EventHandler<T>, 
        // Func<T>, Action<T> etc
        // public delegate void Notify();
        public event EventHandler ThreasholdViolated;
        
        protected void OnThreasholdViolated()
        {
           var handler = ThreasholdViolated;
           if (handler != null)
             handler(this, EventArgs.Empty);
        }
    
        public abstract void CheckThreshold();
      }
    
      class B : A
      {
        public override void CheckThreshold()
        {
           OnThreasholdViolated();
        }
      }
