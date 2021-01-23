    // dynamically load assembly from file Test.dll
    Assembly testAssembly = Assembly.LoadFile(@"c:\Test.dll");
    // get type of class Calculator from just loaded assembly
    Type calcType = testAssembly.GetType("Test.Calculator");
    // create instance of class Calculator
    object calcInstance = Activator.CreateInstance(calcType);
    // get info about property: public double Number
    PropertyInfo numberPropertyInfo = calcType.GetProperty("Number");
