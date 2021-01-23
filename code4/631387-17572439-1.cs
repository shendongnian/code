    public bool OnLoad(object entity, object id, System.Collections.IDictionary state)
    {
        var isSampling = state["IsSampling"] as bool?;
        if( entity is IAccount && isSampling.HasValue )
        {
            if( !isSampling )
                Log.Write( string.Format( "Sampling for Account with id {0} is not active", id ) );
        }
        return false;
    }
