      public static int FirstBetween<T>( this List<T> list, T value) where T:IComparable<T> {
            if (list == null)
                return -1;
            if (value == null)
                return -1;
            if (list.Count == 0)
                return 0;
            for (int index = 1; index < list.Count; index++) {
                if (( list[index - 1].CompareTo( value ) < 0 ) 
                      && list[index].CompareTo( value ) > 0)
                    return index;
            }
            return list.Count;
        }
