        public class AttributePairComparer : IEqualityComparer<AttributePair>
        {
            public bool Equals(AttributePair x, AttributePair y)
            {
                return x.RoleUri.Equals(y.RoleUri);
            }
            public int GetHashCode(AttributePair obj)
            {
                return obj.RoleUri.GetHashCode();
            }
        }
