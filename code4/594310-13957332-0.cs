    public class A
    {
      public double Add(double a, double b)
      {
        if (a == null || b == null)
          throw new ArgumentNullException("");
        return a + b;
      }
    }
    
    [TestClass()]
    public UnitTest
    {
      [TestMethod()]
      public void ATest()
      {
        try
        {
          double d = new A().Add(null, 1);
        }
        catch(ArgumentNullException ex)
        {
          //Fail the test
          Assert.Fail("");
          //Or throw, this will allow you to double click the exception in the unit test and go to the line of code which failed
          throw ex;
        }  
      }
    }
