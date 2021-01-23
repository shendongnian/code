    FieldDesc x = new StandardHoursByCommunitySvcType();
    StandardHoursByCommunitySvcType y = new StandardHoursByCommunitySvcType();
    x.A(); // OK
    x.B(); // Fails (does not compile)
    ((StandardHoursByCommunitySvcType)x).B(); // OK
    x.V(); // OK, prints "V from StandardHoursByCommunitySvcType"
    y.A(); // OK
    y.B(); // OK
    y.V(); // OK, prints "V from StandardHoursByCommunitySvcType"
