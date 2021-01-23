 public void TestThisStuff()
        {
            // 1 example
            MyDerivedClass derivedObj = new MyDerivedClass();
            derivedObj.Field = "Changed field";
            derivedObj.FieldDerived = "Changed derived field";
            MyBaseClass baseObj = (MyBaseClass)derivedObj;
            // baseObj.Field value will be "Changed field"
            // baseObj.FieldDerived will not be accessible because it is not presend in the base class
                // 2 example
                MyDerivedClass derivedObj2 = new MyDerivedClass();
                derivedObj2.Field = "Changed field";
                derivedObj2.FieldDerived = "Changed derived field";
                MyBaseClass baseObj2 = new MyBaseClass();
                // baseObj2.Field value will be "Hello"
                // baseObj2.FieldDerived will not be accessible because it is not presend in the base class
                baseObj2.Field = "Change my field because it's not related to anything else."
                // derivedObj2.Field value will be "Changed field"
                // derivedObj2.FieldDerived will not be accessible because it is not presend in the base class
            }
