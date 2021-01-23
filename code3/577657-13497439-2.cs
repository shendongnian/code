    BroadCastBlock<Foo> bcb = new BroadCastBlock<Foo>(foo);
    ...
    
    if ( aBlock1.HasResult ) 
    {
        bcb.Add( aBlock1.Result );
    }
    
    if ( aBlock2.HasResult ) 
    {
        bcb.Add( aBlock2.Result );
    }
