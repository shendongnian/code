        [RegularExpression(@"^\d{10}(\r?\n\d{10})*$", ErrorMessage = "Please enter a valid 10 digit number.")]
        public string TenDigitNumbers
        {
            get;
            set;
        }
