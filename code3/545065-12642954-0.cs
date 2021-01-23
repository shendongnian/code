    using System;
    
    public static class DoubleExtensionMethods
    {
        public static string FormattedTo5(this double number)
        {
            string numberAsText = number.ToString();
        
            if (numberAsText.Length > 5)
            {
                numberAsText = numberAsText.Substring(0, 5);
            }
        
            return numberAsText.TrimEnd('.').PadLeft(5);
        }
    }
