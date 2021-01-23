    namespace MyCode.UnitTests
    {
 
    [TestMethod]
    public void TestminuteChanged()
    {
        //watch for traviling in time
        DateTime baseTime = DateTime.Now;
        DateTime nowforTesting = baseTime;
        Func<DateTime> _getNowForTesting = delegate () { return nowforTesting; };
    
        MyWatch myWatch= new MyWatch(_getNowForTesting );
        nowforTesting = baseTime.AddMinute(1); //skip minute
        //TODO check myWatch
    }
    
    [TestMethod]
    public void TestStabilityOnFebruary29()
    {
        Func<DateTime> _getNowForTesting = delegate () { return new DateTime(2024, 2, 29); };
        MyWatch myWatch= new MyWatch(_getNowForTesting );
        //component does not crash in overlap year
    }
    }
