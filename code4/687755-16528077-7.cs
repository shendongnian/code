    [AttributeUsage( AttributeTargets.Property, AllowMultiple = true )]
    class ArrayToPropertyMap : Attribute
    {
        public string ArrayName
        {
            get;
            set;
        }
        public int ArrayIndex
        {
            get;
            set;
        }
        /* Call this function to do the actuall mapping (target is updated) */
        public static IEnumerable<U> Map<U, T>( IEnumerable<T[]> source, string arrayName ) where U : new()
        {
            if ( !source.Any() )
                return new U[] { };
            var l_mappedProperties =
                typeof( U )
                .GetProperties( System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance )
                .Where(
                    p => ( p.PropertyType == typeof( T ) ) && Attribute.IsDefined( p, typeof( ArrayToPropertyMap ) ) )
                .Select(
                    p => new
                    {
                        Property = p,
                        Attribute = p.GetCustomAttributes( typeof( ArrayToPropertyMap ), true )
                                     .Cast<ArrayToPropertyMap>()
                                     .Where( a => a.ArrayName == arrayName )
                                     .FirstOrDefault()
                    } )
                .Where(
                    p => p.Attribute != null )
                .Select(
                    p => new
                    {
                        Property = p.Property,
                        Index = p.Attribute.ArrayIndex
                    } );
            var l_result = new List<U>();
            foreach ( var array in source )
            {
                var l_target = new U();
                foreach ( var l_mappedProperty in l_mappedProperties )
                    l_mappedProperty.Property.SetValue( l_target, array[l_mappedProperty.Index], null );
                l_result.Add( l_target );
            }
            return l_result;
        }
    }
