    Thread t;
    static void RunAsync(object var1, object var2)
    {
        ThreadStart work = delegate
        {
            try
            {
                Statement1(var1);
                Statement2(var2);
                // etc
            }
            catch (Exception e) { }
        };
        t=new Thread(work);
        t.Start();
    }
    [TestMethod]
    public void TestMethod()
    {
       RunAsync();
       DoOtherStuff();
       if(t!=null)
          t.Join();
    }
