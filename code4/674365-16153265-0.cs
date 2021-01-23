    foreach( string key in result.Properties.PropertyNames )
    {
         if( key == "name" )
         {
             Console.WriteLine("{0}:{1}", key, result.Properties[key]);             
         }
    }
