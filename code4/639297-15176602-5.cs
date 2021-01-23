    object[] someObjects = new object[] { "one", "two", "three" };
    IEnumerable implicitlyCastedToEnumerable = someObjects;
    Type unknownType = (DateTime.Now.Hour > 14) ? typeof(string) : typeof(int);
    IEnumerable apparentlyNothingHappenedHere 
        = implicitlyCastedToEnumerable.DynamicCast(unknownType);
    
    // if it's not after 14:00, then an exception would've jumped over this line and
    // straight out the exit bracket or into some catch clause
    // it it's after 14:00, then the apparentlyNothingHappenedHere enumerable can do this:
    IEnumerable<string> asStrings = (IEnumerable<string>)apparentlyNothingHappenedHere;
    // whereas the earlier would've cause a cast exception at runtime
    IEnumerable<string> notGoingToHappen = (IEnumerable<string>)implicitlyCastedToEnumerable;
