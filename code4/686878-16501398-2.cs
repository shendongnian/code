    public class Invoice: IClonable
    {
     public int No;
     public DateTime Date;
     public Person Customer;
     //.............
    
     public object Clone()
     {
     Invoice myInvoice = (Invoice)this.MemberwiseClone();
     myInvoice.Customer = (Person) this.Customer.Clone();
     return myInvoice;
     }
    }
    
    public class Person: IClonable
    {
     public string Name;
     public int Age;
    
     public object Clone()
     {
     return this.MemberwiseClone();
     }
    }
 
