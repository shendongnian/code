    public bool HasCity
    {
       get 
       { 
         return (this.Contact!=null && this.Contact.Address!= null && this.Contact.Address.City != null); 
       }     
    }
