       [ReliabilityContract(Consistency.MayCorruptInstance, Cer.MayFail)]
       public static void Sort<T>(T[] array, int index, int length, System.Collections.Generic.IComparer<T> comparer) {
           // Argument checking code omitted
           //...
           if (length > 1) {
               // <STRIP>
               // TrySZSort is still faster than the generic implementation.
               // The reason is Int32.CompareTo is still expensive than just using "<" or ">".
               // </STRIP>
               if ( comparer == null || comparer == Comparer<T>.Default ) {
                   if(TrySZSort(array, null, index, index + length - 1)) {
                       return;
                   }
               }
               ArraySortHelper<T>.Default.Sort(array, index, length, comparer);
           }
       }
