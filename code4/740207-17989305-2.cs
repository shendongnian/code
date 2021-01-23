    [Fact]
    public void CreatePersonWithoutFillingCollectionProperty()
    {
        var fixture = new Fixture().Customize(new DoNotFillCollectionProperties());
        var actual = fixture.Create<Person>();
        Assert.Null(actual.OtherClasses);
    }
    [Fact]
    public void CreateManyStillWorks()
    {
        var fixture = new Fixture().Customize(new DoNotFillCollectionProperties());
        var actual = fixture.CreateMany<Person>();
        Assert.NotEmpty(actual);
    }
    [Fact]
    public void CreatListStillWorks()
    {
        var fixture = new Fixture().Customize(new DoNotFillCollectionProperties());
        var actual = fixture.Create<List<Person>>();
        Assert.NotEmpty(actual);
    }
    [Fact]
    public void CreateCollectionStillWorks()
    {
        var fixture = new Fixture().Customize(new DoNotFillCollectionProperties());
        var actual = fixture.Create<ICollection<Person>>();
        Assert.NotEmpty(actual);
    }
