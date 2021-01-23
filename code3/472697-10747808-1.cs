    public class C
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Int32 I {
            get {
                throw new System.NotSupportedException();
            }
            set {
                throw new System.NotSupportedException();
            }
        }
    }
