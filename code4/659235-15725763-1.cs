    class Whatever
    {
        private const decimal InvalidHouseNum = decimal.MinValue;
    
        public Whatever(...)
        {
            // ...
            HouseNumber = InvalidHouseNum;
        }
        public bool IsValid
        {
            get
            {
                return (!String.IsNullOrWhiteSpace(StreetName) && !String.IsNullOrWhiteSpace(City) && HouseNumber != InvalidHouseNum  );
            }
        }
    
    }
