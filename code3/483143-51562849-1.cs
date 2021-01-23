    public static class PredicateBuilderStore
    {
        public static Func<BsonDocument, bool> GetPredicateForBsonDocument(Entity entity)
    	{
    		var predicate = PredicateBuilder.True<BsonDocument>();            
    		predicate = predicate.And(d => d.GetElement({key}).Value == CompareWithValue);
    		return predicate.Compile();
    	}   
    }
