    public class B : A
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        new public Int32 MyProperty {
            get;
            set;
        }
    }
