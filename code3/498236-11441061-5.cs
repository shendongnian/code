    Mapper.CreateMap<Source,Destination>();
	Mapper.CreateMap<List<Source>,List<Destination>>().ConvertUsing(new CollectionConverter());
	
	var sourceCollection = new List<Source>
	{
		new Source{ Id = 1, Foo = "Match"},
		new Source{ Id = 2, Foo = "DoesNotMatchWithDestination"}
	};
	var destinationCollection = new List<Destination>
	{
		new Destination{ Id = 1, Foo = "Match"},
		new Destination{ Id = 3, Foo = "DoeNotMatchWithSource"}
	};
	var mergedCollection = Mapper.Map(sourceCollection, destinationCollection);
