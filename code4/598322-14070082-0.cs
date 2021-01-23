    public static class SomeClass
        {
            public static Guid? With(this Guid? o, object x)
            {
                if (x is System.DBNull) return null;
                return o = (Guid)x;
            }
        }
