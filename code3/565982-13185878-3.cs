    var a = new A();
    var b = new B();
    var aAsBase = a as Base;
    var bAsBase = b as Base;
    a.Say(); // 42
    aAsBase.Say(); // Hello World!
    b.Say(); // Goodbye, Cruel World!
    bAsBase.Say(); // Goodbye, CruelWorld!
