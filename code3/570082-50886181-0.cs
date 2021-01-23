        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "OldTableName", schema: "dbo", newName: "NewTableName", newSchema: "dbo");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "NewTableName", schema: "dbo", newName: "OldTableName", newSchema: "dbo");
        }
