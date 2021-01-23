    class TimereportMappers
    {
        public Days dayMap(Day input)
        {
            return new Days
            {
                Date = input.Date,
                Hour = input.Hours
            };
        }
    
    }
