    using System.Linq;
    // with exception in case of cast error
    var derivedCollection = baseCollection.Cast<MyDerived>().ToList();
    // without exception in case of cast error
    var derivedCollection = baseCollection.OfType<MyDerived>().ToList();
