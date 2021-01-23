    [TestAttribute(Name = "Test")]
    void TestMethod() {
        MethodInfo thisMethod = GetType().GetMethod("TestMethod", BindingFlags.Instance | BindingFlags.NonPublic);
        Test3(thisMethod);
    }
    static void Test3(MethodInfo caller) {
        var attributes = caller.GetCustomAttributes(typeof(TestAttribute), false);
        TestAttribute testAttribute = attributes[0] as TestAttribute;
        if (testAttribute != null) {
            Console.Write(testAttribute.Name);
        }
    }
