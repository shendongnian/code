        public class Country
    {
       public int ID {get;set;}
    
       public virtual ICollection<Currency> Currencys {get;set;}//don't worry about the name,     pluralisation etc
    
    
    }
    
    public class Currency
    {
    
       public int ID {get;set;}
    
       public virtual ICollection<Country> Countrys {get;set;}//same as above - 
    
    }
