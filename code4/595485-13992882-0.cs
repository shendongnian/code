    public class CustomerCollection : List<Customer> // at this time, you have all methods from List such as Add, Remove, [index] etc...
    {
       public double AverageAge()
       {
           return this.Average(customer => customer.Age)
       }
    
       // other methods...
    }
