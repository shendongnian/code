    IFoo iFoo = new Bar();
    iFoo.SpecificBehaviorMethod1(); //Bar implementation will be called;
    IFoo iFoo = new BarOnSteroids();
    iFoo.SpecificBehaviorMethod1(); //BarOnSteroids implementation will be called.
    iFoo.CommonBehaviorMethod1(); //Bar implementation will be called.
    Bar bar = new BarOnSteroids();
    bar.SpecificBehaviorMethod1(); //BarOnSteroids implementation will be called.
    bar.CommonBehaviorMethod1(); //Bar implementation will be called.
