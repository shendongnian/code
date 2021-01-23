    [XmlRoot(ElementName="Employee")]    
    public class Employee    
    {    
      [XmlElement(ElementName="FirstName")]    
      public string FirstName {get;set;}
      
      [XmlElement(ElementName="LastName")]
      public string LastName {get;set;}
      
      [XmlElement(ElementName="DOB")]
      public DateTime DOB {get;set;}
      
      [XmlElement(ElementName="Address")]
      public string Address {get;set;}
      
      [XmlElement(ElementName="Transaction")]
      public List<Transaction> Transaction {get;set;}
    }
    
    
    [XmlRoot(ElementName="Transaction")]
    public class Transaction
    {
    
      [XmlElement(ElementName="Month")]
      public int Month {get;set;}
      
      [XmlElement(ElementName="Amount")]
      public int Amount {get;set;}
    }
