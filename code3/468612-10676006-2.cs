    class MyObject
    {
        public Guid Id { get; set; }
        public override bool Equals(object other)
        {
            if (other is MyObject)
            {
                // use the 'Id' property as identifier
                MyObject myObj = (MyObject)obj;
                return myObj.Id == this.Id;
            }
            // is not a 'MyObject' based object
            return base.Equals(other);
        }
    }
