    public class Migrations : DataMigrationImpl
    {
        SchemaBuilder.CreateTable("CaptureRecord",
                table => table
                .ContentPartRecord()
                .Column<string>("CaptureName")
                .Column<int>("SupplierOptionsRecord_id");
     
        SchemaBuilder.CreateTable("OptionsRecord",
                table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<string>("Name"));
        return 1;
    }
