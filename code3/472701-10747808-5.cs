    public class B : A
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new int MyProperty {
            get {
                throw new System.NotSupportedException();
            }
            set {
                throw new System.NotSupportedException();
            }
        }
    }
