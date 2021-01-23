    static void VerifyFeaturesetFullyMapped(
    	IEnumerable<Output> outputs,
    	IEnumerable<Input> inputs )
    {
    	Assert.All(
    		inputs.FullOuterJoin( outputs,
    			f => f.Item1, r => r.Name,
    			( x, y, key ) => new { 
                    InDescription = x.Item2, 
                    OutDescription = y.Description } ),
    		inout =>
    			Assert.Equal( inout.InDescription, inout.OutDescription ) );
    }
