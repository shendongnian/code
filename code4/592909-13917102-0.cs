    public class S
    {
            private class ObInfo<T>
            {
                private string _type;
                private T _value;
    
                public ObInfo(string i_Type, T Value)
                {
                    this._type = i_Type;
                    this._value = Value;
                }
    
                public ObInfo() 
                {}
    
               private static Dictionary<int,ObInfo<T>> sObj= new Dictionary<int,ObInfo<T>>();
           }
    }
