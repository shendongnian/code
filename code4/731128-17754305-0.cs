    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            
            Map(x => x.Name);
            Map(x => x.HashedPassword);
        }
    }
    public class StudentMap : SubclassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            References(x => x.School);
            Map(x => x.GPA);
        }
    }
    public class TeacherMap : SubclassMap<Teacher>
    ...
