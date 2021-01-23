    public class BigList<T>
    {
        public Object[] internalArray = new Object[Int16.MaxValue];
        public T this[BigInteger i]
        {
            get
            {
                if (i < Int16.MaxValue-1)
                {
                    return (T)internalArray[(int)i];
                }
                else
                {
                    i = i - int.MaxValue;
                    BigList<T> following = (BigList<T>)internalArray[Int16.MaxValue-1];
                    if (following != null)
                    {
                        return following[i];
                    }
                    else
                    {
                        throw new KeyNotFoundException();
                    }
                }
            }
            set
            {
                if (i < Int16.MaxValue-1)
                {
                    internalArray[(int)i] = value;
                }
                else
                {
                    i = i - int.MaxValue;
                    BigList<T> following = (BigList<T>)internalArray[Int16.MaxValue-1];
                    if (following == null)
                    {
                        following = new BigList<T>();
                        internalArray[Int16.MaxValue - 1] = following;
                    }
                    following[i] = value;
                }
            }
        }
    }
