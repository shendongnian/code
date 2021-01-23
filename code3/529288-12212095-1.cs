    class Segment : IEquatable<Segment>
    {
        // ...
        public bool Equals(Segment other)
        {                        
            return 
                (object)other != null &&
                other.V1 == V1 && 
                other.V2 == V2;
        }     
    }
