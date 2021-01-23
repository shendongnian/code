    public class SingleItemList<T>:Banana, IEnumerable<T> where T:Banana {
        public static explicit operator T(SingleItemList<T> enumerable) {
            return enumerable.SingleOrDefault();
        }
        // Others omitted...
    }
