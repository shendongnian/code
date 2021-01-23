    static public class Metadata<T>
    {
        static public readonly Type Type = typeof(T); //cache type to avoid avcessing global metadata dictionary
        
        static public class Attribute<TAttribute>
            where TAttribute : Attribute
        {
                static public readonly TAttribute Value = Metadata<T>.Type.GetCustomAttributes(Metadata<TAttribute>.Type).SingleOrDefault() as TAttribute; 
        }
    }
    //usage
    Metadata<MyType>.Attribute<MyAttributeType>.Value; //exception if more then once and null if not defined.
