    class A { }
    class B { }
    class G<T> { }
    class G1<T> : G<A> { }
    class G2 : G1<B> { }
    //...
    Type argument1 = GetGenericArgument(typeof(G2)); // B
    Type argument2 = GetGenericArgument(typeof(G2),1 ); // A
    //...
    static Type GetGenericArgument(Type type, int level = 0) {
        do {
            if(type.IsGenericType && 0 == level--)
                return type.GetGenericArguments()[0];
            type = type.BaseType;
        }
        while(type != null);
        return null;
    }
