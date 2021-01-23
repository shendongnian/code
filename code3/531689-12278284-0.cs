    public class ClassAMap : ClassMap<ClassA>
    {
        public ClassAMap()
        {
            Table("ClassA");
            // Only load Class A where the user is not removed
            Where("PersonRecId in (select u.Userid from Users u where u.Removed = 0)");
            Id(c => c.Id).GeneratedBy.Identity();
            References<User>(x => x.User).ForeignKey("UserId");
        }
    }
