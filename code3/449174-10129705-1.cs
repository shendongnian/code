    public class StringLengthValidatedType
    {
        public const int MaximumLength = 3;
        [StringLength(MaximumLength)]
        public string Property { get; set; }
    }
    [Fact]
    public void CreateAnonymousWithStringLengthValidatedTypeReturnsCorrectResult()
    {
        // Fixture setup
        var fixture = new Fixture();
        // Exercise system
        var result = fixture.CreateAnonymous<StringLengthValidatedType>();
        // Verify outcome
        Assert.True(result.Property.Length <= StringLengthValidatedType.MaximumLength);
        // Teardown
    }
