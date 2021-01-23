        public void PublicApiMethod(string name)
        {
            name.CheckArg<UserName>("name");
            // TODO: Do stuff...
        }
        internal void InternalMethod(string name)
        {
            name.DebugAssert<UserName>();
            // TODO: Do stuff...
        }
        internal bool ValidateInput(string name, string email)
        {
            return name.IsValid<UserName>() && email.IsValid<Email>();
        }
