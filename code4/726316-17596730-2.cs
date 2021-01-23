    public sealed class POCOComparer<TPOCO> : IEqualityComparer<TPOCO> where TPOCO : class
    {
        public bool Equals(TPOCO poco1, TPOCO poco2)
        {
            if (poco1 != null && poco2 != null)
            {
                bool areSame = true;
                foreach(var property in typeof(TPOCO).GetPublicProperties())
                    {
                        object v1 = property.GetValue(poco1, null);
                        object v2 = property.GetValue(poco2, null);
                        if (!object.Equals(v1, v2))
                        {
                            areSame = false;
                            break;
                        }
                    });
                return areSame;
            }
            return poco1 == poco2;
        }   // eo Equals
        public int GetHashCode(TPOCO poco)
        {
            int hash = 0;
            foreach(var property in typeof(TPOCO).GetPublicProperties())
            {
                object val = property.GetValue(poco, null);
                hash += (val == null ? 0 : val.GetHashCode());
            });
            return hash;
        }   // eo GetHashCode
    }   // eo class POCOComparer
