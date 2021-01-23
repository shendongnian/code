        public override void Up()
        {
            RenameColumn(table: "Schema.MyTable", name: "OldName", newName: "NewName");
        }
        
        public override void Down()
        {
            RenameColumn(table: "Schema.MyTable", name: "NewName", newName: "OldName");
        }
