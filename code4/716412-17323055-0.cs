        public string GetString(CultureInfo culture) {
            var integral = (int)Math.Truncate(Value);
            var integralLength = integral.ToString().Length;
            if (integralLength > MaxLength) {
                throw new InvalidOperationException();
            }
            var integralWithDecimalSeparatorLength = integralLength + culture.NumberFormat.NumberDecimalSeparator.Length;
            var minimumFixedPointLength = integralWithDecimalSeparatorLength + 1;
            if (minimumFixedPointLength > MaxLength) {
                var intValue = (int)Math.Round(Value);
                return intValue.ToString("D" + MinLength, culture);
            } 
            var precision = MaxLength - integralWithDecimalSeparatorLength;
            return Value.ToString("F" + precision, culture);
        }
