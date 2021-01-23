    public abstract class UserAccountViewModel : ObservableObject, IViewModel
    {
        //use private member and do a RaisePropertyChanged("Username")
        public string Username { get; set; }
        private void GetUserInformation()
        {
            Username = Environment.UserName;
        }
    }
