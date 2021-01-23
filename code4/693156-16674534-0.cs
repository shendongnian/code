        bool? ParseInput(string input)
        {
            int integerInput;
            if (int.TryParse(input, out integerInput))
                return integerInput == 1;
            return null;
        }
