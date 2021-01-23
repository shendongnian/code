    public partial class UserControl1 : UserControl
    {
        #region Dependency Properties
        public static readonly DependencyProperty MinutesRemainingProperty =
                    DependencyProperty.Register
                    (
                        "MinutesRemaining", typeof(int), typeof(UserControl1),
                        new UIPropertyMetadata(10)
                    );
        #endregion
        public int MinutesRemaining
        {
            get
            {
                return (int)GetValue(MinutesRemainingProperty);
            }
            set
            {
                SetValue(MinutesRemainingProperty, value);
            }
        }
       public UserControl1()
        {
            InitializeComponent();
        }
    }
