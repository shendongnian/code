    public struct Nullable<T> where T : struct {
        public bool HasValue {
            get { /* true if has a value, otherwise false */ }
        }
        public T Value {
            get {
                if(!HasValue)
                    throw new InvalidOperationException();
                return /* returns the value */
            }
        }
    }
