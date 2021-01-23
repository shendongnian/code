        class FotoEqualityComparer : IEqualityComparer<Foto>
        {
        public bool Equals(Foto b1, Foto b2)
        {
                if (b1.smallurl == b2.smallurl)                
                    return true;                
                else        
                    return false;        
        }
        public int GetHashCode(Foto bx)
        {
                int hCode = bx.smallurl ;
                return hCode.GetHashCode();
        }
        }
