    [Test]
    public void ExecuteHackedViaFields()
    {
        var model = TypeModel.Create();
        var type = model.Add(typeof(KeyValuePair<int, A>), false);
        type.Add(1, "key");
        type.AddField(2, "value").AsReference = true;
        model[typeof(B)][2].AsReference = false; // or just remove AsReference on Items
        Execute(model);
    }
