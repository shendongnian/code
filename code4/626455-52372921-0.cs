    protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestingPeriodYear",
                table: "ControlActivityIssue");
            migrationBuilder.AddColumn<int>(
                name: "TestingPeriodYear",
                table: "ControlActivityIssue",
                nullable: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestingPeriodYear",
                table: "ControlActivityIssue");
            migrationBuilder.AddColumn<DateTime>(
                name: "TestingPeriodYear",
                table: "ControlActivityIssue",
                nullable: true);
        }
