    public class UserSpecializationMap : SubclassMap<UserSpecialization>
    {
        public UserSpecializationMap()
        {
            Table("PersonSpecialization");
    
            Id(c => c.Id).GeneratedBy.Identity();
    
            DiscriminatorValue("UserSpecialization");
    
            HasManyToMany(x => x.Roles).Cascade.All()...;
        }
    }
