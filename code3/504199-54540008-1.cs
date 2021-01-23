        public double ConvertToDouble(string input)
        {
            input = input.Trim();
            if (input.Contains(",") && input.Split(',').Length == 2)
            {
                return Convert.ToDouble(input, _commaCulture);
            }
            if (input.Contains(".") && input.Split('.').Length == 2)
            {
                return Convert.ToDouble(input, _pointCulture);
            }
            throw new Exception("Invalid input");
        }
