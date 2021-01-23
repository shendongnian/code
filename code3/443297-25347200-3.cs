	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.IO;
	using System.Text.RegularExpressions;
	public abstract class ExpandedDbMigration
		: System.Data.Entity.Migrations.DbMigration
	{
		public void SqlFile(string path)
		{
			var cleanAppDir = new Regex(@"\\bin.+");
			var dir = AppDomain.CurrentDomain.BaseDirectory;
			dir = cleanAppDir.Replace(dir, "") + @"\";
			var sql = File.ReadAllLines(dir + path);
			string[] ignore = new string[]
			{
				"GO",	// Migrations doesn't support GO
				"/*",	// Migrations might not support comments
				"print"	// Migrations might not support print
			};
			foreach (var line in sql)
			{
				if (ignore.Any(ig => line.StartsWith(ig)))
					continue;	
				Sql(line);
			}
		}
	}
