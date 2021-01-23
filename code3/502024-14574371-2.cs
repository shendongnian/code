    public partial class Screen : Form, IInterface
    {
        // Base Class here, complete with .designer.cs and .resx
        public Screen()
        {
            InitialiseComponent();
        }
        #region IInterface imported methods
        public partial void SomeMethod()
        {
            // Do something.
        }
        #endregion
    }
