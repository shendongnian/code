    public override void Up() {
      // create table
      CreateTable("dbo.MyTable", ...;
      Sql("ALTER TABLE MyTable ADD CONSTRAINT U_MyUniqueColumn UNIQUE(MyUniqueColumn)");
    }
    public override void Down() {
      Sql("ALTER TABLE MyTable DROP CONSTRAINT U_MyUniqueColumn");
    }
