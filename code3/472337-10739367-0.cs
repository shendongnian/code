        public static string FormatAccountNumber2(string accountNumber)
        {
            if (string.IsNullOrEmpty(accountNumber))
                return string.Empty;
            if (accountNumber.Length < 4)
                return "****";
            
            return new string('*', accountNumber.Length - 4) +
                accountNumber.Substring(accountNumber.Length - 4);
        }
