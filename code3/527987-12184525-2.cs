    public class CodeCustomMapper : ClassMapper<Code>
    {
        public CodeCustomMapper()
        {
            base.Table("Codes");
            Map(f => f.Id).Key(KeyType.Identity);
            Map(f => f.Type).Column("Type");
            Map(f => f.Value).Column("Code");
            Map(f => f.Description).Column("Foo");
        }
    }
