    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 983;
            foreach (var item in _wrappedEnumerable)
               if(item != null)
                  hash = hash * 457 + item.GetHashCode();
            return hash;
        }
    }
