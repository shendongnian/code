        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "OldColumnName", table: "TableName", newName: "NewColumnName", schema: "dbo");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "NewColumnName", table: "Orders", newName: "OldColumnName", schema: "dbo");
        }
