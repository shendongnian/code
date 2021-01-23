    class MyArrayComparer : EqualityComparer<object[]>
    {
        public override bool Equals(object[] x, object[] y)
        {
            if (x.Length != y.Length) { return false; }
            for (int i = 0; i < x.Length; i++)
            {
                if (!x[i].Equals(y[i]))
                {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode(object[] obj)
        {
            return 0;
        }
    }
