    OurViewModel v = new OurViewModel();
    MyViewModel m = new MyViewModel();
    IValidatableObject ivo = v;
    ivo.Validate(null);
    ivo = m;
    ivo.Validate(null);
