    public class NumberContainer<T>
            where T : struct, IConvertible
        {
            public T ValueA { get; private set; }
            public T ValueB { get; private set; }
            public T Total {
                get
                {
                    // do type checking here, then:
    
                    return (T)Convert.ChangeType(
                        Convert.ToDouble((object)ValueA) +
                        Convert.ToDouble((object)ValueB), typeof(T));
                } 
            }
        }
