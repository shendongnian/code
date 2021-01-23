    public class EqualityFieldsSetup<T>
        where T : class
    {
        private List<Func<T, object>> _propertySelectors;
        public EqualityFieldsSetup()
        {
            _propertySelectors = new List<Func<T, object>>();
        }
        public EqualityFieldsSetup<T> Add(Func<T, object> propertySelector)
        {
            _propertySelectors.Add(propertySelector);
            return this;
        }
        public bool Equals(T objA, object other)
        {
            //If both are null, then they are equal 
            //    (a condition I think you missed)
            if (objA == null && other == null)
                return true;
            T objB = other as T;
            if (objB == null)
                return false;
            if (object.ReferenceEquals(objA, objB))
                return true;
            foreach (Func<T, object> propertySelector in _propertySelectors)
            {
                object objAProperty = propertySelector.Invoke(objA);
                object objBProperty = propertySelector.Invoke(objB);
                //If both are null, then they are equal
                //   move on to the next property
                if (objAProperty == null && objBProperty == null)
                    continue;
                //Boxing requires the use of Equals() instead of '=='
                if (objAProperty == null && objBProperty != null ||
                    !objAProperty.Equals(objBProperty))
                    return false;
            }
            return true;
        }
        public int GetHashCode(T obj)
        {
            int hashCode = 0;
            foreach (Func<T, object> propertySelector in _propertySelectors)
            {
                object objProperty = propertySelector.Invoke(obj);
                if (objProperty != null)
                    hashCode ^= objProperty.GetHashCode();
            }
            return hashCode;
        }
    }
