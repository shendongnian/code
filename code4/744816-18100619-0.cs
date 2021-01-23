	data = MyEntity.GetEntities(_db).OrderBy(a=> a.name)
				.Select(b=> new NameIdentity
				{
					ID = b.entityID,
					Name = EdmFunctions.Concat(b.year, "-", b.name) 
				});
