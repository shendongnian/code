        public Quantity ConvertToUnit(string newUnit)
        {
            var newValue = ... calculate value with new unit
            return new Quantity(newValue, newUnit);
        }
