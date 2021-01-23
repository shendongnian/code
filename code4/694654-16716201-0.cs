    static void VerifyFeaturesetFullyMapped(
    	IEnumerable<MyOutput> results,
    	IEnumerable<Tuple<string, string>> inputs )
    {
    	Assert.All(
    		inputs.FullOuterJoin( results,
    			f => f.Item1, r => r.Name,
    			( x, y, key ) => new { 
                    InDescription = x.Item2, 
                    OutDescription = y.Description } ),
    		inout =>
    			Assert.Equal( inout.InDescription, inout.OutDescription ) );
    }
