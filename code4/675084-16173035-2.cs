    public class LoginViewModel
    {
        Window dialog;
        public bool ShowLogin()
        {
           dialog = new UserView();
           dialog.DataContext = this; // set up ViewModel into View
           if (dialog.ShowDialog() == true)
           {
             return true;
           }
           return false;
        }
    
    	ICommand _loginCommand
    	public ICommand LoginCommand
    	{
    		get
    		{
    			if (_loginCommand == null)
    				_loginCommand = new RelayCommand(param => this.Login());
    
    			return _loginCommand;
    		}
    	}
       
        public void CloseLoginView()
    	{
                if (dialog != null)
    		  dialog.Close();
    	}	
       
    	public void Login()
    	{
    		if(CheckLogin()==true)
    		{
    			CloseLoginView();         
    		}
    		else
    		{
    		  // write error message
    		}
    	}
        public bool CheckLogin()
        {
          // ... check login code
          return true;
        }
    }
