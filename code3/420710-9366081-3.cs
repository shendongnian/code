    FieldDesc fd = new StandardHoursByCommunitySvcType();
    StandardHoursByCommunitySvcType svc = new StandardHoursByCommunitySvcType();
    fd.A(); // OK
    fd.B(); // Fails (does not compile)
    ((StandardHoursByCommunitySvcType)fd).B(); // OK
    fd.V(); // OK, prints "V from StandardHoursByCommunitySvcType"
    svc.A(); // OK
    svc.B(); // OK
    svc.V(); // OK, prints "V from StandardHoursByCommunitySvcType"
