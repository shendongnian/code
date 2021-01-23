    public class EnumsByStringName : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name 
                && c.SourceProp.Type.IsEnum 
                && c.TargetProp.Type.IsEnum;
        }
        protected override object SetValue(ConventionInfo c)
        {
            return Enum.Parse(c.TargetProp.Type, c.SourceProp.Value.ToString());
        }
    }
    public class F1
    {
        public EnumTargetType P1 { get; set; }
    }
    [Test]
    public void Tests()
    {
        var s = new { P1 = EnumSourceType.Val3 };
        var t = new F1();
        t.InjectFrom<EnumsByStringName>(s);
        Assert.AreEqual(t.P1, EnumTargetType.Val3);
    }
