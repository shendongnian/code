    // first, default:
    DemoClass demoObject = new DemoClass();
    Console.WriteLine(demoObject.ModifyString("My test string")); 
    // now, pure "override":
    demoObject.ModifyString = testVal => 
            { return String.Concat(testVal, ", this time with question marks????"); 
            };
    Console.WriteLine(demoObject.ModifyString("Second test string"));
    // finally, define a delegate that overrides and calls default:
    DemoClass.MyDelegate combined = testVal => 
            { return String.Concat(DemoClass.DefaultBehavior(testVal), 
                                   ", now we're really tricky"); 
            };
    demoObject.ModifyString = combined;
    Console.WriteLine(demoObject.ModifyString("Third test string"));
