	using System;
	using System.Text.RegularExpressions;
	using System.Data.Entity.Migrations;
	using System.IO;
	using System.Linq;
	public partial class FillTable : DbMigration
	{
		public override void Up()
		{
	var cleanAppDir = new Regex(@"\\bin.+");
	var dir = AppDomain.CurrentDomain.BaseDirectory;
	dir = cleanAppDir.Replace(dir, "") + @"\";
	var sql = File.ReadAllLines(dir + @"Sql\2014-08-16-LoadIn.sql")
		.Where(l => l.StartsWith("INSERT")).ToArray(); // This line optional 
	foreach (var line in sql)
		Sql(line);
