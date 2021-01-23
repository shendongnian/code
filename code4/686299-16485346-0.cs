    [TestMethod]
    public void TestGetMethod()
    {
        StackTrace st = new StackTrace();
        StackFrame sf = st.GetFrame(0);
        MethodBase currentMethodName = sf.GetMethod();
        Assert.IsTrue(currentMethodName.ToString().Contains("TestGetMethod"));
     }
    
