        public class tobj : IEquatable<tobj>
        {
            public string column1;
            public string column2;
            public bool Equals(tobj other)
            {
                return other != null ? Equals(column1, other.column1) && Equals(column2, other.column2) : false;
            }
            public override bool Equals(object obj)
            {
                return Equals(obj as tobj);
            }
            public override int GetHashCode()
            {
                // seed the code
                int hash = 13;
                // use some primes to mix in the field hash codes...
                hash = hash * 17 + column1.GetHashCode();
                hash = hash * 17 + column2.GetHashCode();
                return hash
            }
        }  
