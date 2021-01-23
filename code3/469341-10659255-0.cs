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
                // do some hash code work here to combine the codes
                return column1.GetHashCode() + (17 * column2.GetHashCode());
            }
        }  
