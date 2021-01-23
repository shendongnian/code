    public ICommand AddPhoneCommand
    {
        get
        {
            return new Command<string>((x) =>
            {
                if(x != null) { AddPhone(x); }
            };
        }
    }
