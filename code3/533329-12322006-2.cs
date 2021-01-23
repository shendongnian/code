     private sealed class SomeFieldEqualityComparer : IEqualityComparer<Ant>
        {
            public bool Equals(Ant x, Ant y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }
                if (ReferenceEquals(x, null))
                {
                    return false;
                }
                if (ReferenceEquals(y, null))
                {
                    return false;
                }
                if (x.GetType() != y.GetType())
                {
                    return false;
                }
                return string.Equals(x._someField, y._someField);
            }
            public int GetHashCode(Ant obj)
            {
                return (obj._someField != null ? obj._someField.GetHashCode() : 0);
            }
        }
