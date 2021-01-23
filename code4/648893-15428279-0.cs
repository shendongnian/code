    [TestAttribute(Name = "Test")]
    static void Test() {
        Test2();
    }
    static void Test2() {
        StackTrace st = new StackTrace(1);
        var attributes = st.GetFrame(0).GetMethod().GetCustomAttributes(typeof(TestAttribute), false);
        TestAttribute testAttribute = attributes[0] as TestAttribute;
        if (testAttribute != null) {
            Console.Write(testAttribute.Name);
        }
    }
