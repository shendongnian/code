		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			
			
			connectionString = "URI=file:" + GetiPhoneDocumentsPath() + "/SqliteTestDB.db";
			
		} else {
			
			connectionString = "URI=file:SqliteTestDB.db";			
			
		}
		
		Debug.Log ("Connection String = " + connectionString);
	 	 
		IDbConnection dbcon;
		dbcon = (IDbConnection)new SqliteConnection (connectionString);
		dbcon.Open (); 
