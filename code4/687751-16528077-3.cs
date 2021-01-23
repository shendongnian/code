    class Program
    {
        static void Main( string[] args )
        {
            /* You already have an array... */
            string[] arr = new string[] { "Value 1", "Value 2", "Value 3" };
            /* ...and an object instance... */
            LotsaProps1 obj = new LotsaProps1();
            /* ...so this is really the only code you'd need to add to your
               business logic: */
            ArrayToPropertyMap.Map( arr, obj );
            /* This code is just used to show that the example works: */
            Console.WriteLine( "Prop1 = '" + obj.Prop1 + "'" );
            Console.WriteLine( "Prop2 = '" + obj.Prop2 + "'" );
            Console.WriteLine( "Prop3 = '" + obj.Prop3 + "'" );
            Console.WriteLine( "Prop4 = '" + obj.Prop4 + "'" );
            Console.ReadKey( true );
        }
    }
