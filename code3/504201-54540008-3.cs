        public double ConvertToDouble(string input)
        {
            input = input.Trim();
            if (input == "0") {
                return 0;
            }
            if (input.Contains(",") && input.Split(',').Length == 2)
            {
                return Convert.ToDouble(input, commaCulture);
            }
            if (input.Contains(".") && input.Split('.').Length == 2)
            {
                return Convert.ToDouble(input, pointCulture);
            }
            throw new Exception("Invalid input!");
        }
