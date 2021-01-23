    public SomeClass
    {
        private const string UrlValidatorRegex = "http://...
        private const DateTime MinValidSomeDate = ...
        private const DateTime MaxValidSomeDate = ...
        public string SomeUrl { get; set; }
        public DateTime SomeDate { get; set; }
        ...
        private bool ValidateProperties()
        {
            var urlValidator = new RegEx(urlValidatorRegex);
            if (!urlValidator.IsMatch(this.Someurl))
            {
                return false;
            }
            if (this.SomeDate < MinValidSomeDate 
                || this.SomeDate > MinValidSomeDate)
            {
                return false;
            }
            ...
            // Check other fields and properties here, return false on failure.
            ...
            return true;
        }
    }
