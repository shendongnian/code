     public RelayCommand<Window> CloseWindowCommand { get; private set; } // the <Window> is important for your solution!
    
     public MainViewModel() 
     {
         //initialize the CloseWindowCommand. Again, mind the <Window>
         //you don't have to do this in your constructor but it is good practice, thought
         this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
     }
     public bool CheckLogin(Window loginWindow) //Added loginWindow Parameter
     {
        var user = context.Users.Where(i => i.Username == this.Username).SingleOrDefault();
        if (user == null)
        {
            MessageBox.Show("Unable to Login, incorrect credentials.");
            return false;
        }
        else if (this.Username == user.Username || this.Password.ToString() == user.Password)
        {
            MessageBox.Show("Welcome "+ user.Username + ", you have successfully logged in.");
            this.CloseWindow(loginWindow); //Added call to CloseWindow Method
            return true;
        }
        else
        {
            MessageBox.Show("Unable to Login, incorrect credentials.");
            return false;
        }
     }
     
     //Added CloseWindow Method
     private void CloseWindow(Window window)
     {
         if (window != null)
         {
             window.Close();
         }
     }
