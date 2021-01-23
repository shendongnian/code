    bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
    {
        if (other == null) return false;
    
        if (!object.ReferenceEquals(this, other))
        {
            Array array = other as Array;
            if ((array == null) || (array.Length != this.Length))
            {
                return false;
            }
            for (int i = 0; i < array.Length; i++)
            {
                object x = this.GetValue(i);
                object y = array.GetValue(i);
    
                if (!comparer.Equals(x, y))
                {
                    return false;
                }
            }
        }
        
        return true;
    }
