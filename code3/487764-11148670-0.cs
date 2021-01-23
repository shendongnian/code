    public enum TableTypeEnum
    {
        Template =0,
        TestPlan =1
    }
    public abstract class UnitBase
    {   
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public TableTypeEnum TableType { get; private set; }
        protected UnitBase(TableTypeEnum  type)
        {
            TableType = type;
        }
    }
    public class TemplateUnit:UnitBase
    {
        public int TemplateForeignKeyId { get; set; }
        public TemplateUnit() : base(TableTypeEnum.Template)
        {}
    }
    public class TestPlanUnit:UnitBase
    {
        public Guid TestplanForeignKeyId { get; set; }
        public TestPlanUnit():base(TableTypeEnum.TestPlan)
        {}
    }
