    public class FirstViewModel 
		: MvxViewModel
    {
        public FirstViewModel()
        {
            IsPressed = true;
        }
		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}
        public bool _isPressed;
        public bool IsPressed
        {
            get { return _isPressed; }
            set { _isPressed = value; RaisePropertyChanged(() => IsPressed); }
        }
    }
