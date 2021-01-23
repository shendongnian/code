    [Test]
    public void ExecuteHackedViaFields()
    {
        // I'm using separate models **only** to keep them clean between tests;
        // normally you would use RuntimeTypeModel.Default
        var model = TypeModel.Create();
        // configure using the fields of KeyValuePair<int,A>
        var type = model.Add(typeof(KeyValuePair<int, A>), false);
        type.Add(1, "key");
        type.AddField(2, "value").AsReference = true;
         // or just remove AsReference on Items
        model[typeof(B)][2].AsReference = false;
        Execute(model);
    }
