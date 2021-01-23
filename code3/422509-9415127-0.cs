    public class Customer
    {
      public string FirstName { get; private set; }
      public string LastName { get; private set; }
      public string PhoneNumber { get; private set; }
      public Customer(string firstName, string lastName, string phoneNumber)
      {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
      }
    }
---
    Customer customer = new Customer("John", "Doe", "0123245676");
