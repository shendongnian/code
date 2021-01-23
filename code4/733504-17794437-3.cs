        public static int FirstBetween<T>( this List<T> list, T value) where T:IComparable<T> {
            if (list == null && value == null) return -1;
            if (list.Count == 0) return 0;
            var last = value.CompareTo( list[0] );
            for (int index = 1; index < list.Count; index++) {
                if (( last > 0 ) &&  (last = value.CompareTo(list[index] )) < 0)
                    return index;
            }
            return list.Count;
        }
