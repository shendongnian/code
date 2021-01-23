    public partial class ProcessesByStartTimeForm : Form {
        // ... init stuff
        public static readonly IEnumerable<object> ProcessQuery
            = from p in new DeferredEnumerable<Process>(() => Process.GetProcesses())
              let startTime = Eval.TryEvalOrDefault<DateTime?>(() => p.StartTime)
              orderby startTime
              select new {
                  Process = p.ProcessName,
                  StartTime = startTime, // could be null
                  Title = p.MainWindowTitle
              };
        class DeferredEnumerable<T> : IEnumerable<T> {
            readonly Func<IEnumerable<T>> f;
            public DeferredEnumerable(Func<IEnumerable<T>> f) {
                this.f = f;
            }
            public IEnumerator<T> GetEnumerator() {
                return this.f().GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return this.GetEnumerator();
            }
        }
    }
