    public enum UnitType
    {
        Feet = 0 ,Meters = 1
    }
    
    public Length
    {
        public Length(decimal lenInMeters)
        {
            _lenInMeters = lenInMeters;
        }
        
        private decimal _lenInMeters;
        private decimal ConvertToMeters(decimal feet)
        {
            //do conversion
        }
 
        private decimal ConvertToFeet(decimal meter)
        {
            //do conversion
        }
  
        private void ChangeByFeet(decimal feetChange)
        {
            _lenInMeters + ConvertToMeters(feetChange);
        }
        
        public void Change(decimal amount, UnitType units)
        {
               switch(units)
               {
                  case(UnitType.Meters):
                      _lenInMeters+=amount;
                      return;
                  case(UnitType.Feet):
                      _lenInMeters+=ConvertToMeters(amount);
                      return;
                  case(default):
                      throw new ApplicationException("not supported type");
               }
        }
        
        public decimal InFeet
        {
            get
            {
                return ConvertToFeet(_lenInMeters);
            }
        }
        
        public decimal InMeters
        {
            get
            {
                return _lenInMeters;
            }
        }
    }
