    var dto1 = "{\"favorite\":1}".FromJson<Item>();
    Assert.That(dto1.IsFavorite, Is.True);
    var dto0 = "{\"favorite\":0}".FromJson<Item>();
    Assert.That(dto0.IsFavorite, Is.False);
    var dtoTrue = "{\"favorite\":true}".FromJson<Item>();
    Assert.That(dtoTrue.IsFavorite, Is.True);
    var dtoFalse = "{\"favorite\":false}".FromJson<Item>();
    Assert.That(dtoFalse.IsFavorite, Is.False);
