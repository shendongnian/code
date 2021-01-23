    class Program
    {
        static void Main( string[] args )
        {
            /* You should already have the arrays... */
            string[][] arr1 = new string[][] { 
                new string[] { "Value A 1", "Value A 2", "Value A 3" },
                new string[] { "Value A 4", "Value A 5", "Value A 6" },
                new string[] { "Value A 7", "Value A 8", "Value A 9" },
            };
            string[][] arr2 = new string[][] { 
                new string[] { "Value B 1", "Value B 2", "Value B 3", "Value B 4" },
                new string[] { "Value B 5", "Value B 6", "Value B 7", "Value B 8" },
                new string[] { "Value B 9", "Value B 10", "Value B 11", "Value B 12" },
            };
            /* ...so this is really the only code you'd need to add to your
                  business logic: */
            var l_objs1 = ArrayToPropertyMap.Map<LotsaProps1, string>( arr1, "Array1" );
            var l_objs2 = ArrayToPropertyMap.Map<LotsaProps1, string>( arr2, "Array2" );
            /* This code is just used to show that the example works: */
            Console.WriteLine( "Array1:" );
            foreach ( var l_obj in l_objs1 )
            {
                Console.Write( "Prop1='" + l_obj.Prop1 + "'; " );
                Console.Write( "Prop2='" + l_obj.Prop2 + "'; " );
                Console.Write( "Prop3='" + l_obj.Prop3 + "'; " );
                Console.WriteLine( "Prop4 = '" + l_obj.Prop4 + "'" );
            }
            Console.WriteLine( "Array2:" );
            foreach ( var l_obj in l_objs2 )
            {
                Console.Write( "Prop1='" + l_obj.Prop1 + "'; " );
                Console.Write( "Prop2='" + l_obj.Prop2 + "'; " );
                Console.Write( "Prop3='" + l_obj.Prop3 + "'; " );
                Console.WriteLine( "Prop4 = '" + l_obj.Prop4 + "'" );
            }
            Console.ReadKey( true );
        }
    }
