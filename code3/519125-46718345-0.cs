    private ICommand _cancelCommand; 		
    public ICommand CancelCommand 		
    {
       get 			
         {
            if (_cancelCommand == null)
               {
                  _cancelCommand = new DelegateCommand<Window>(
						x =>
 						{
 							x?.Close();
 						});
 				}
 
 				return _cancelCommand; 			
         } 		
    }
