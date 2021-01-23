	public PathDto GetPath(string tableType, string id)
	{
		using (var context = new PathsEntities())
		{
				var type = Type.GetType(tableType);
				var p = context.Set(type).Find(id);
				return (PathDto)p;
		}
	}
