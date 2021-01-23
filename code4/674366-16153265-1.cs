    foreach( string key in result.Properties.PropertyNames )
    {
         if( key == "name" )
         {
             IEnumerable collection = result.Properties[key];
             string[] seperateValues = collection.Cast<object>().Select(o => o.ToString()).ToArray();
             string joinedValues = String.Join(", ", seperateValues)
             Console.WriteLine("{0}:{1}", key, joinedValues);             
         }
    }
