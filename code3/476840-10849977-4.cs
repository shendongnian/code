    [CompilerGenerated]
    private sealed class <Read>d__0 : IEnumerable<YourObject>, IEnumerable, IEnumerator<YourObject>, IEnumerator, IDisposable
    {
        // Fields
        private int <>1__state;
        private YourObject <>2__current;
        public string <>3__filename;
        public Foo <>4__this;
        private int <>l__initialThreadId;
        public FileStream <filestream>5__1;
        public string <line>5__3;
        public StreamReader <reader>5__2;
        public string filename;
    
        // Methods
        [DebuggerHidden]
        public <Read>d__0(int <>1__state);
        private void <>m__Finally4();
        private void <>m__Finally5();
        private bool MoveNext();
        [DebuggerHidden]
        IEnumerator<YourObject> IEnumerable<YourObject>.GetEnumerator();
        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator();
        [DebuggerHidden]
        void IEnumerator.Reset();
        void IDisposable.Dispose();
    
        // Properties
        YourObject IEnumerator<YourObject>.Current { [DebuggerHidden] get; }
        object IEnumerator.Current { [DebuggerHidden] get; }
    }
