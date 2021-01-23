    public class DailyDependencyTableMap : EntityTypeConfiguration<DailyDependencyTable>
    {
        public SomeTableMap(string schemaName) {
            this.ToTable("SOME_TABLE_1", schemaName.ToUpper());
            //Map other properties and stuff
        }
    }
