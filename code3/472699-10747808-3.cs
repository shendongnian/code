    public class B : A
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public Int32 MyProperty {
            get {
                throw new System.NotSupportedException();
            }
            set {
                throw new System.NotSupportedException();
            }
        }
    }
