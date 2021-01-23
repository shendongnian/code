        public void IsStringEmpty(string input, Action<bool, Exception> callback)
        {
            try
            {
                if (string.IsNullOrEmpty(input)) callback(true, null);
                else callback(false, null);
            }
            catch (Exception ex)
            {
                callback(false, ex);
            }
        }
        public void Test()
        {
            string test = string.Empty;
            
            // show busy indicator here
            IsStringEmpty(test, (result, error) =>
            {
                //hide busy indicator here
                if (error == null)
                {
                    if (result) { /* string is empty */}
                    else { /* string is not empty */}
                }
                else
                {
                    /* show/log error?*/
                }
            });
        } 
