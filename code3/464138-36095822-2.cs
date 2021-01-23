	public class ParentObject
	{
		public ParentObject()
		{
			ChildSetOne = new List<ChildObjectOne>();
			ChildSetTwo = new List<ChildObjectTwo>();
		}
        // 1) Although its possible to do this without this Id property, For sanity it is advisable.
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<ChildObjectOne> ChildSetOne {get; private set;}
		public ICollection<ChildObjectTwo> ChildSetTwo { get; private set; }
	}
	public class ChildObjectOne
	{
        // 2a) Need a ParentId
		public int ParentId { get; set; }
		public string Name { get; set; }
	}
	public class ChildObjectTwo
	{
        // 2b) This ParentId is not required but again for sanity it is advisable to include it.
		public int ParentId { get; set; }
		public int id { get; set; }
		public string LocationName { get; set; }
	}
	public class Repository
	{
		public IEnumerable<ParentObject> Get()
		{
			string sql = 
				@"SELECT 
					p.Id, 
					p.Name, 
					o.Name, 
					o.ParentId, 
					t.Id, 
					t.LocationName, 
					t.ParentId 
				FROM 
					Parent p 
						LEFT JOIN ChildOne o on o.ParentId = p.Id 
						LEFT JOIN ChildTwo t on t.ParentId = p.Id 
				WHERE 
					p.Name LIKE '%Something%'";
			var lookup = new Dictionary<int, ParentObject>();
			using (var connection = CreateConnection())
			{
				
				connection.Query<ParentObject, ChildObjectOne, ChildObjectTwo, ParentObject>(
					sql, (parent, childOne, childTwo) =>
					{
						ParentObject activeParent;
					
						if (!lookup.TryGetValue(childOne.ParentId, out activeParent)) 
						{
							activeParent = parent;
							lookup.add(activeParent.Id, activeParent);
						}
					
						//TODO: if you need to check for duplicates or null do so here
						activeParent.ChildSetOne.Add(childOne);
						//TODO: if you need to check for duplicates or null do so here
						activeParent.ChildSetTwo.Add(childTwo);
					});   
			}
			return lookup.Values;
		}
	}
