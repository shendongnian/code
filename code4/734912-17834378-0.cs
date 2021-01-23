	public class NameDetails
	{
		public int Id {get;set;}
		public string Name {get;set;}
	}
		
	List<NameDetails> Names = new List<NameDetails>
		{
			new  NameDetails{Id = 1, Name = "Name 1"},
			new NameDetails{Id = 2 , Name = "Name 2"},
		};
		
	var toFetch = Names.Select(n => n.Id).ToArray();
	var association = context.NameDetails
                             .Where(n => toFetch.Contains(n.Id))
                             .ToDictionary(n => n.Id);
	foreach(var name in Names)
	{
		NameDetails existing;
		if(association.TryGetValue(name.Id, out existing))
		{
			// It exists, map the properties in name to existing
		}
		else
		{
			// It's new, perform some logic and add it to the context
			context.NameDetails.Add(name);
		}
	}
	context.SaveChanges()
