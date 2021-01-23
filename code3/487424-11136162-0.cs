        public void IsStringEmpty(string input, Action<bool> callback)
        {
            if (string.IsNullOrEmpty(input)) callback(true);
            else callback(false);
        }
        public void Test()
        {
            string test = string.Empty;
            IsStringEmpty(test, (result) =>
            {
                if (result) { /* string is empty */}
                else { /* string is not empty */}
            });
        }
