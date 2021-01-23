    Parse timespan to DateTime. For Example.    
    //The time will be "8.30 AM" or "10.00 PM" or any time like this format.
        public TimeSpan GetTimeSpanValue(string displayValue) 
            {   
                DateTime dateTime = DateTime.Now;
                    if (displayValue.StartsWith("10") || displayValue.StartsWith("11") || displayValue.StartsWith("12"))
                              dateTime = DateTime.ParseExact(displayValue, "hh:mm tt", CultureInfo.InvariantCulture);
                        else
                              dateTime = DateTime.ParseExact(displayValue, "h:mm tt", CultureInfo.InvariantCulture);
                        return dateTime.TimeOfDay;
                    }
