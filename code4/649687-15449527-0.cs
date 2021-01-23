    decimal value = 10;
            int decimalPosition = 3; //this decimalPosition will be dynamically change.
            string position = "";
    
            for (int i = 0; i < decimalPosition; i++)
            {
                position += "0";
            }
            string newValue = value.ToString() + "." + position;
            decimal formatted = Convert.ToDecimal(newValue);
