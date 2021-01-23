        public AddResult Load(string userName, string password)
        {
            AddResult addResult = null;
            // validate
            if (userName == "")
            {
                addResult = new AddResult("", false) { ErrorMessage = "wrong" };
            }
            // want to return object AddResult
            return addResult;
        }
