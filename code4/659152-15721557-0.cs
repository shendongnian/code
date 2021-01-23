    public partial class RestrictionUserControl : UserControl, IRestrictionUserControl
    {
        public RestrictionUserControl(GeneralRestriction r)
        {
            InitializeComponent();
            Foo = r;
        }
        public GeneralRestriction Foo
        {
            get
            {
                //some code
            }
            protected set
            {
                //some code
            }
        }
    }
