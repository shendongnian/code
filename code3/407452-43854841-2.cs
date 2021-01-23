    [Test]
    public void OperationsAreCorrect()
    {            
        var docField = new Field<Document> {Value = new Document {Content = "Hello World"}};
        var intField = new Field<int> {Value = 17};
        var dateField = new Field<DateTime>();
        FieldOperator.Operate(new Field[] {docField, intField, dateField});
        Assert.IsTrue(docField.Label == docField.GetType().ToString());
        Assert.IsTrue(intField.Label == intField.GetType().ToString());
        Assert.IsTrue(dateField.Label == "Oops");
        Assert.IsTrue(docField.Value.Content == "Foo Bar");
        Assert.IsTrue(intField.Value == 600842);
        Assert.IsTrue(dateField.Value == default(DateTime));
    }
