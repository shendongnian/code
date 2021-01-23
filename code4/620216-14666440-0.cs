    var types = [ typeof(JSONCommandDTO), typeof(JSONProfileDTO), typeof(JSONMessageDTO) ];
    var json = deserializer.GetInstance( ... );
    var jsonPropertyNames = json.GetType().Properties( Flags.InstancePublic )
        .OrderBy( p => p.Name );
    var match = types.FirstOrDefault( t => t.Properties( Flags.InstancePublic )
        .OrderBy( p => p.Name )
        .SequenceEqual( jsonPropertyNames ) );
    if( match != null ) // got match, proceed to step 3 
