	static void ShowClassNamesAndFields() {
		using (IObjectContainer db = Db4oEmbedded.OpenFile("mydb.db4o")) {
			var dbClasses = db.Ext().StoredClasses();
			foreach (var dbClass in dbClasses) {
			    Debug.Print(dbClass.GetName());
			    foreach (var dbField in dbClass.GetStoredFields()) {
			        Debug.Print("    " + dbField.GetName());
			    }
			}
		}
	}	
