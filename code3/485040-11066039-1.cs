    class PersonAddress()
    {
        public override string ToString()
        {
            return string.Concat(this.Street, ", ",  this.City, ", ", this.Postcode);
        }
    }
    
    class Person()
    {
        public override string ToString()
        {
            return string.Concat(this.Name, ", ",  this.PersonAddress.ToString());
        }
    }
