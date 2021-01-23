    foreach(var tester in objects)
    {
        if (tester is GroupTester)
        {
           (tester as GroupTester).GroupTesterOnlyProperty = true;
        }
    }
