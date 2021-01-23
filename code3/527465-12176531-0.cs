    public class Foo_LineItems : AbstractIndexCreationTask
    {
    	public override IndexDefinition CreateIndexDefinition()
    	{
    		return new IndexDefinition
    		{
    			Map = @"
    					from foo in docs.Foos
    					where foo.Baz == null
    					select new { foo.Id, foo.Bar }
    "
    		};
    	}
    }
