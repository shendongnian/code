    [AttributeUsage( AttributeTargets.Property )]
    class ArrayToPropertyMap : Attribute
    {
        public int ArrayIndex
        {
            get;
            set;
        }
        /* Call this function to do the actuall mapping (target is updated) */
        public static void Map<T>( T[] source, object target )
        {
            var l_mappedProperties =
                target.GetType()
                .GetProperties( System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance )
                .Where(
                    p => ( p.PropertyType == typeof( T ) ) && Attribute.IsDefined( p, typeof( ArrayToPropertyMap ) ) )
                .Select(
                    p => new
                    {
                        Property = p,
                        Index = ( (ArrayToPropertyMap) p.GetCustomAttributes( typeof( ArrayToPropertyMap ), true ).First() ).ArrayIndex
                    } );
            foreach ( var l_mappedProperty in l_mappedProperties )
                l_mappedProperty.Property.SetValue( target, source[l_mappedProperty.Index], null );
        }
    }
