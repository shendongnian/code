        private bool IsOkToExecute
		{
			get { return _isOkToExecute; }
			set
			{
				_isOkToExecute = value;
				RaisePropertyChanged("IsOkToExecute");
			}
		}
		 private void myOkExecute (object parameter)
		 {
		 	IsOkToExecute = false;
		 }
		private void myCancelExecute(object parameter)
		 {
			 IsOkToExecute = true;
		 }
    private bool myCanOkExecute(object parameter)
    {
    	return IsOkToExecute;
    }
    private bool myCanCancelExecute(object parameter)
    {
    	return !IsOkToExecute;
    }
