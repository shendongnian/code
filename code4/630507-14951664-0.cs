            public static bool operator ==(ItemCapsule  x, ItemCapsule  y)
            {
                bool xnull, ynull;
                xnull = Object.ReferenceEquals(x, null);
                ynull = Object.ReferenceEquals(y, null);
                if (xnull && ynull) return true;
                if (xnull || ynull) return false;
                return x.Equals(y);
            }
    
            public static bool operator !=(ItemCapsule  x, ItemCapsule  y)
            {
                bool xnull, ynull;
                xnull = Object.ReferenceEquals(x, null);
                ynull = Object.ReferenceEquals(y, null);
                if (xnull && ynull) return false;
                if (xnull || ynull) return true;
                return !x.Equals(y);
            }
    
            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                return ((ItemCapsule )obj).Id == Id;
            }
