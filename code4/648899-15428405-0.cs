    [TestAttribute(Name = "Test")]
    public void Test()
    {
        Test2(MethodBase.GetCurrentMethod());
    }
    
    public viod Test2(MethodBase sender)
    {
        var attr = sender.GetCustomAttributes(typeof(TestAttribute), false).FirstOrDefault();
        if(attr != null)
        {
           TestAttribute ta = attr as TestAttribute;
           Console.WriteLine(ta.Name);
        }
    }
