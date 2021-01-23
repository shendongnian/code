    public class Landlord : UserProfile
    {
        [Key]
        public Guid Id {get;set;} //If you named this "LandlorId" you wouldn't need the [Key]
    
    //this convention will wire up to the otherside    
    public virtual ICollection<ResidentialProperty> ResidentialProperties { get; set; }
    
    }
    
    public class ResidentialProperty{
       [Key]
       public Guid Id {get;set;}
    
       //this convention will wire up to the otherside
       public LandLordId {get;set;}
       public Landlord Landlord {get;set;}
    }
