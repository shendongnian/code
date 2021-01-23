        public bool TryGetPreisAsDecimal(string price, out decimal convertedPrice)
        { 
            Match match = Regex.Match(price,@"\d+(\.\d{1,2})?");
            if (match != null)
            {
                convertedPrice = decimal.Parse(match.Value);
                return true;
            }
            else
            {
                convertedPrice = 0.0m;
                return false;
            }
        }
