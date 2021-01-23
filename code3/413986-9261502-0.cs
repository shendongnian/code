    // using the example above, we are at the beginning of step 6 inside session #2
    // we have 2 important objects = ISession sessionTwo, Option objectA.
    // Option is an entity defined by you, it is not part of NH.
    objectA.SomeProperty = "blah";
    var optionFromSessionTwo = (Option) sessionTwo.Merge(objectA);
    // this will not throw
    sessionTwo.SaveOrUpdate(optionFromSessionTwo);
