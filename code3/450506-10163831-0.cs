    class TheViewModel
    {
        public string CompanyName { get; set; }
        public string UsernameText { get; set; }
        public string PasswordText { get; set; }
        
        private bool Validate()
        {
            bool result = !QuickMethods.IsFullyEmpty(CompanyName) &&
                    !QuickMethods.IsFullyEmpty(UsernameText) &&
                    !QuickMethods.IsFullyEmpty(PasswordText);
            return result;
        }
    }
