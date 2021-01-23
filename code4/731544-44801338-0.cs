    var x = new object();
    Assert.That(x, Is.SameAs(x)); // success
    Assert.That(x, Is.Not.SameAs(x)); // fail
    var y = new object();
    Assert.That(x, Is.SameAs(y)); // fail
    Assert.That(x, Is.Not.SameAs(y)); // success
