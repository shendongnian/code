    namespace MigrationsDemo.Migrations
    {
      using System;
      using System.Data.Entity.Migrations;
    
    public partial class SomeClassThatisATable : DbMigration
    {
        public override void Up()
        {
            AddColumn("MyTable", "MyColumn", c => c.String( defaultvalue:"Mydefault"  ));
        }
