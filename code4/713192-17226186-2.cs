    public ClassZ MyMethod (Class1 class1Var, Class2 class2Var)
    {
        Func<bool, bool, string, ClassZ> myFunc 
                 = (predicate, prop1Value, string1Value) => 
                          predicate 
                          ? new ClassZ { Property1 = prop1Value, String1 = string1Value }
                          : null;
        return myFunc((class1Var.SomeBool && !class2Var.SomeBool), false, "This is string1")
               ?? myFunc((class1Var.SomeBool && !class2Var.IsMatch(class2Var)), true)
               ?? myFunc((class1Var.SomeProperty.HasValue && !class2Var.SomeBool), false, "This is string2");
    }
