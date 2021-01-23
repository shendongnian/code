    class MyEqualityComparerer : IEqualityComparer<MyMessage>
        {
            public bool Equals(MyMessage x, MyMessage y)
            {
                if (x == null && y == null)
                {
                    return true;
                }
    
                if (x == null)
                {
                    return false;
                }
    
                if (y == null)
                {
                    return false;
                }
    
                return x.Id == y.Id;
            }
    
            public int GetHashCode(MyMessage obj)
            {
                if(obj == null)
                {
                    return 0;
                }
    
                return obj.Id.GetHashCode();
            }
        }
