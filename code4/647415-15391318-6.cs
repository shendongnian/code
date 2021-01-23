        private DelegateCommand<object> loginCommand;
        loginCommand = new DelegateCommand<object>(this.Login);
        public DelegateCommand<object> LoginCommand{
                    get { return loginCommand ; }
                }
