    using System.Threading;
    public class Something {
        private ImmutableDictionary<string, string> dict = ImmutableDictionary<string, string>.Empty;
        public void Add(string key, string value) {
           // It is important that the contents of this loop have no side-effects
           // since they can be repeated when a race condition is detected.
           do {
              var original = _dict;
              if (local.ContainsKey(key)) {
                 return;
              }
              var changed = original.Add(key,value);
              // The while loop condition will try assigning the changed dictionary
              // back to the field. If it hasn't changed by another thread in the
              // meantime, we assign the field and break out of the loop. But if another
              // thread won the race (by changing the field while we were in an 
              // iteration of this loop), we'll loop and try again.
           } while (Interlocked.CompareExchange(ref this.dict, changed, original) != original);
        }
    }
