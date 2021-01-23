    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace PropertyMapper
    {
        /* This part just runs the example */
        class Program
        {
            static void Main( string[] args )
            {
                string[] arr = new string[] { "Value 1", "Value 2", "Value 3" };
                LotsaProps1 obj = new LotsaProps1();
                ArrayToPropertyMap.Map( arr, obj );
                Console.WriteLine( "Prop1 = '" + obj.Prop1 + "'" );
                Console.WriteLine( "Prop2 = '" + obj.Prop2 + "'" );
                Console.WriteLine( "Prop3 = '" + obj.Prop3 + "'" );
                Console.WriteLine( "Prop4 = '" + obj.Prop4 + "'" );
                Console.ReadKey( true );
            }
        }
        /* This is the custom attribute you use to map a property to an index */
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
        /* This is an example class (so you can see it working) */
        class LotsaProps1
        {
            /* Prop1 is mapped to array index 0 */
            [ArrayToPropertyMap( ArrayIndex = 0 )]
            public string Prop1
            {
                get;
                set;
            }
            /* Prop2 is mapped to array index 2 */
            [ArrayToPropertyMap( ArrayIndex = 2 )]
            public string Prop2
            {
                get;
                set;
            }
            /* Prop3 is not mapped */
            public string Prop3
            {
                get;
                set;
            }
            /* Prop4 is mapped to array index 1 */
            [ArrayToPropertyMap( ArrayIndex = 1 )]
            public string Prop4
            {
                get;
                set;
            }
        }
    }
