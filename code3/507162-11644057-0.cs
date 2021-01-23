    [Test, ExpectedException(typeof(InvalidOperationException),
        ExpectedMessage = "Data of this type has inbuilt behaviour, and cannot be added to a model in this way: System.Object")]
    public void TestShouldntBeAbleToCreateMetaTypeForObject()
    {
        var model = TypeModel.Create();
        model.Add(typeof (object), false);
    }
