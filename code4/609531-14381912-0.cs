    public class Entity
    {
        [EnumDataType(typeof(MyEnum))]
        public MyEnum EnumValue { get; set; }
    }
    [Fact]
    public void TestInvalidEnumValue()
    {
        Entity entity = new Entity { EnumValue = (MyEnum)(-126) };
        // -126 is stored in the entity.EnumValue property
        Assert.Throws<ValidationException>(() =>
            Validator.ValidateObject(entity, new ValidationContext(entity, null, null), true));
    }
