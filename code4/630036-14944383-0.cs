    [Table("Landlord")]
    public class Landlord : UserProfile
    {
        // A Landlord can have many ResidentialProperties
        public virtual ICollection<ResidentialProperty> ResidentialProperties { get; set; }
    }
    
    [Table("ResidentialProperty")]
    public class ResidentialProperty
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ResidentialPropertyId { get; set; }
    
        // A ResidentialProperty has 1 Landlord
        // Foreign key is on many side and it contains value of primary key on one side
        // In your case FK must contain value of property's landlord
        public virtual int UserId { get; set; }
        // ForeignKey attribute pairs navigation property on many side with foreign key propety 
        [ForeignKey("UserId")]
        public virtual Landlord Landlord { get; set; } 
    }
