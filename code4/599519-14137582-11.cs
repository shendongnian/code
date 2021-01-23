    // FindBaseClassWith returns null if one of parameters was an interface. 
    // FindBaseClassWith  return null if any of parameter was null. 
    Assert.That(typeof(DeriviedLeft).FindBaseClassWith(typeof(DeriviedLeft)), Is.EqualTo(typeof(DeriviedLeft)));
    Assert.That(typeof(DeriviedLeft).FindBaseClassWith(typeof(SubDeriviedLeft)), Is.EqualTo(typeof(DeriviedLeft)));
    Assert.That(typeof(DeriviedLeft).FindBaseClassWith(typeof(DeriviedRight)), Is.EqualTo(typeof(object)));
    Assert.That(typeof(DeriviedLeft).FindBaseClassWith(typeof(object)), Is.EqualTo(typeof(object)));
    Assert.That(typeof(DeriviedLeft).FindBaseClassWith(typeof(Another)), Is.EqualTo(typeof(object)));
    Assert.That(typeof(DeriviedRight).FindBaseClassWith(typeof(DeriviedRight)), Is.EqualTo(typeof(DeriviedRight)));
    Assert.That(typeof(DeriviedRight).FindBaseClassWith(typeof(DeriviedLeft)), Is.EqualTo(typeof(object)));
    Assert.That(typeof(object).FindBaseClassWith(typeof(object)), Is.EqualTo(typeof(object)));
    Assert.That(typeof(DeriviedLeft).FindBaseClassWith(typeof(IDerivied)), Is.Null);
    Assert.That(typeof(IDerivied).FindBaseClassWith(typeof(IDerivied)), Is.Null);
    Assert.That(typeof(IDerivied).FindBaseClassWith(null), Is.Null);
    
