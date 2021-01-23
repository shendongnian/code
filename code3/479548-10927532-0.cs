    public class UsersMap : ClassMapping<Users>
    {
    		public UsersMap()
    		{
    			Table("Users");
    			Id(u => u.Id, args => args.Generator(Generators.Guid));
    			Property(u => u.Name, args => args.NotNullable(true));
    			Discriminator(t => {
    			            t.Force(true);
    			            t.Insert(true);
    			            t.Length(32);
    			            t.NotNullable(true);
    			            t.Type(NHibernateUtil.String);
    			            t.Column("Discriminator");
    			        });
    			DiscriminatorValue("User");
    		}
    }
    
    public class MUserMap : SubclassMapping<MUser>
    {
    		public MUserMap()
    		{
    			Property(u => u.IsReal, args => args.NotNullable(true));
    			DiscriminatorValue("MUser");
    		}
    }
