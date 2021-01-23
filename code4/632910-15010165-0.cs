        public decimal TryGetPreisAsDecimal(string price)
        { 
            decimal decimalValue = 0.0m;
            Match match = Regex.Match(price,@"\d+(\.\d{1,2})?");
            if (match != null)
            {
               decimalValue = decimal.Parse(match.Value);
            }
            return decimalValue;
        }
