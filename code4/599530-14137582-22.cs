    // FindInterfaceWith returns null if they don't have common implemented interface. 
    // FindBaseClassWith  return null if any of parameter was null. 
    Assert.That(typeof(DeriviedLeft).FindInterfaceWith(typeof(DeriviedLeft)), Is.EqualTo(typeof(IDeriviedLeft)));
    Assert.That(typeof(DeriviedLeft).FindInterfaceWith(typeof(SubDeriviedLeft)), Is.EqualTo(typeof(IDeriviedLeft)));
    Assert.That(typeof(DeriviedLeft).FindInterfaceWith(typeof(DeriviedRight)), Is.EqualTo(typeof(IDerivied)));
    Assert.That(typeof(DeriviedLeft).FindInterfaceWith(typeof(object)), Is.Null);
    Assert.That(typeof(DeriviedLeft).FindInterfaceWith(typeof(Another)), Is.Null);
    Assert.That(typeof(DeriviedLeft).FindInterfaceWith(typeof(AnotherDisposable)), Is.EqualTo(typeof(IDisposable)));
    Assert.That(typeof(DeriviedRight).FindInterfaceWith(typeof(DeriviedRight)), Is.EqualTo(typeof(IDeriviedRight)));
    Assert.That(typeof(DeriviedRight).FindInterfaceWith(typeof(DeriviedLeft)), Is.EqualTo(typeof(IDerivied)));
    Assert.That(typeof(object).FindInterfaceWith(typeof(object)), Is.Null);
    Assert.That(typeof(object).FindInterfaceWith(null), Is.Null);
