    class HashSet<T>
    {
        struct Element
        {
            int Hash;
            int Next;
            T item;
        }
    
        int[] buckets=new int[Capacity];
        Element[] data=new Element[Capacity];
    
        bool Contains(T item)
        {
            int hash=item.GetHashCode();
            // Bucket lookup is a simple array lookup => cheap
            int index=buckets[(uint)hash%Capacity];
            // Search for the actual item is linear in the number of items in the bucket
            while(index>=0)
            {
               if((data[index].Hash==hash) && Equals(data[index].Item, item))
                 return true;
               index=data[index].Next;          
            }
            return false;
        }
    }
