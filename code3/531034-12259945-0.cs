    public class MyClass()
    {
      public delegate ICustomerCreditService InterfaceGetter;
      private InterfceGetter getInterface;
      public MyClass(InterfaceGetter iget)
      {
        getInterface = iget;
      }
      public DoSomething()
      {
        using (var customerCreditService = getInterface())
        {
           var creditLimit = customerCreditService.GetCreditLimit(customer.Firstname, customer.Surname, customer.DateOfBirth);       
        }
      }
    }
