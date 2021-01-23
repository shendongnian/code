	public static List<Pers_Synthese> Get_ListeSynthese_all(
		            string codeClient, DateTime DateDeb, DateTime DateFin) {
		var db = new PetaPoco.Database("Soft8Exp_ClientConnStr");
		//you should probably not be storing a query in a file.
		//To be clear: your query should not be wrapped in exec sp_executesql,
		//ADO.NET will do that for you.
		string sql_Syntax = Outils.LoadFileToString(
		    Path.Combine(appDir, @"SQL\Get_ListeSynthese_All.sql"));
		//You'll need to rename Pers_Synthese's properties to match the db,
		// or vice versa, or you can annotate the properties with the column names.
		return db.Fetch<Pers_Synthese>(sql_Syntax, new {
			codeClioent = codeClient, //I suspect this is a typo
			DateDeb,
			DateFin
		});
	}
