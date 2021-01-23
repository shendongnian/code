     // Uses the foreach statement which hides the complexity of the enumerator.
       // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
       public static void PrintKeysAndValues1( IDictionary myCol )  {
          Console.WriteLine( "   KEY                       VALUE" );
          foreach ( DictionaryEntry de in myCol )
             Console.WriteLine( "   {0,-25} {1}", de.Key, de.Value );
          Console.WriteLine();
       }
    
       // Uses the enumerator. 
       // NOTE: The foreach statement is the preferred way of enumerating the contents of a collection.
       public static void PrintKeysAndValues2( IDictionary myCol )  {
          IDictionaryEnumerator myEnumerator = myCol.GetEnumerator();
          Console.WriteLine( "   KEY                       VALUE" );
          while ( myEnumerator.MoveNext() )
             Console.WriteLine( "   {0,-25} {1}", myEnumerator.Key, myEnumerator.Value );
          Console.WriteLine();
       }
    
       // Uses the Keys, Values, Count, and Item properties.
       public static void PrintKeysAndValues3( HybridDictionary myCol )  {
          String[] myKeys = new String[myCol.Count];
          myCol.Keys.CopyTo( myKeys, 0 );
    
          Console.WriteLine( "   INDEX KEY                       VALUE" );
          for ( int i = 0; i < myCol.Count; i++ )
             Console.WriteLine( "   {0,-5} {1,-25} {2}", i, myKeys[i], myCol[myKeys[i]] );
          Console.WriteLine();
       }
