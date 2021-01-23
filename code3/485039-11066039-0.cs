    class PersonAddress()
    {
        public override string ToString()
        {
            return string.Join(this.Street, ", ",  this.City, ", ", this.Postcode);
        }
    }
    
    class Person()
    {
        public override string ToString()
        {
            return string.Join(this.Name, ", ",  this.PersonAddress.ToString());
        }
    }
