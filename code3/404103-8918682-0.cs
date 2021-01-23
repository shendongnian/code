        public bool ValidateString(string str)
        {
            var strArr = str.Split('/');
            return strArr[0].All(char.IsDigit) && strArr[1].All(char.IsDigit);
        }
