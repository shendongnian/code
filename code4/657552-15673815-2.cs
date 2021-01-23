	public PathDto GetPath(string tableType, string id)
	{
		using (var context = new PathsEntities())
		{
				var type = Type.GetType(tableType);
				var p = context.GetObjectByKey(new EntityKey(tableType, "id", id));
				return (PathDto)p;
		}
	}
