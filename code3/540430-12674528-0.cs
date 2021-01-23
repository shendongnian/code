    // Get all items from drawing Database. All ObjectIds will grouped by types;
    Database db = Application.DocumentManager.MdiActiveDocument.Database;			
    Dictionary<string, List<ObjectId>> dict = new Dictionary<string, List<ObjectId>>();
    using (Transaction t = db.TransactionManager.StartTransaction()) {
    	for (long i = db.BlockTableId.Handle.Value; i < db.Handseed.Value; i++) {
    		ObjectId id = ObjectId.Null;
    		Handle h = new Handle(i);
    		if (db.TryGetObjectId(h, out id)) {
    			string type = id.ObjectClass.Name;
    			if (!dict.Keys.Contains(type))
    				dict.Add(type, new List<ObjectId>());
    			dict[type].Add(id);
    		}
    	}
    	t.Commit();
    }
