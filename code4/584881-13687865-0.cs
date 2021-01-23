    public partial class MyUserControl
    {
        public event EventArgs VisibilityChanged;
        private bool _isTrueAnswer;
        public bool IsTrueAnswer
        {
            get { return _isTrueAnswer; }
            set
            {
                _isTrueAnswer = value;
                VisibilityChanged(this, EventArgs.Empty);
            }
        }
        // etc...
    }
