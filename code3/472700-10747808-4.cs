    public class B : A
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public int MyProperty {
            get;
            set;
        }
    }
