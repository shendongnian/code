    Person { 
     public int PersonID {get;set;}
     public string Name {get;set;}
     //other person properites
    
     //navigation property
     public virtual ICollection<Address> Addresses {get;set;}
    }
