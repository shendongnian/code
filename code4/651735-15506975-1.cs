      public abstract class MySequence : IEnumerable<string> {
        protected string Filename { get; private set; }
    
        public MySequence(string filename) {
          Filename = filename;
        }
    
        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
    
        public IEnumerator<string> GetEnumerator() {
          using (var isf = IsolatedStorageFile.GetUserStoreForApplication()) 
          using (var stream = isf.OpenFile(Filename, FileMode.Open, FileAccess.Read))
          using (var reader = new StreamReader(stream)) {
            return GetEnumerator(reader);
          }
        }
        protected abstract IEnumerator<string> GetEnumerator(StreamReader reader);
      }
      public class MyListSequence : MySequence, IEnumerable<string> {
        public MyListSequence(string filename) : base(filename) {}
        protected override IEnumerator<string> GetEnumerator(StreamReader reader) {
          while (! reader.EndOfStream) yield return reader.ReadLine();
        }
      }
      public class MyStringSequence : MySequence, IEnumerable<string> {
        public MyStringSequence(string filename) : base(filename) {}
        protected override IEnumerator<string> GetEnumerator(StreamReader reader) {
          yield return reader.ReadLine();
        }
      }
