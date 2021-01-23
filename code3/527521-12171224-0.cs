    try {
	    string json = @"{""idBad"":""abc"", ""idGood"":""2"" }";
        JsonSerializer.DeserializeFromString(json, typeof(TestDto));
        Assert.Fail("Exception should have been thrown.");
    } catch (SerializationException ex) {
        Assert.That(ex.Data, Is.Not.Null);
        Assert.That(ex.Data["propertyName"], Is.EqualTo("idBad"));
        Assert.That(ex.Data["propertyValueString"], Is.EqualTo("abc"));
        Assert.That(ex.Data["propertyType"], Is.EqualTo(typeof(int)));
    }
