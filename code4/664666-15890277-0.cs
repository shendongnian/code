    public class SampleClass
    {
       ITestServices _testServices;
       SampleClass(ITestServices testServicesObj)
       {
         _testServices = testServicesObj;
       }
       public string OrderSent()
       {
         return "Orders " + _testServices.OrdersSent().ToString();
       }
    }
