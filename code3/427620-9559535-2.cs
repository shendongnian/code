    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();
      
    string source = "some string to split";
    
    // ALTERNATE: if you want an explicitly typed char[]
    // char[] source = "some string to split".ToCharArray();
    
    for( int i = 0; i < source.Length; i++ )
    {
       if( i % 2 == 0 )
       {
            sb1.Append( source[i] );
       }
       else
       {
            sb2.Append( source[i] );
       } 
    }
