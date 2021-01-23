    class check<T>
    {
        public bool CompareMyValue(T x, T y)
        {
            if (x.Equals(y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
