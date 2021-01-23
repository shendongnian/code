    public abstract class UserMap<TUser> : ClassMap<TUser> where TUser : User
    {
        public UserMap()
        {
            Id(x => x.Id);
            
            Map(x => x.Name);
            Map(x => x.HashedPassword);
        }
    }
    public class StudentMap : UserMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            References(x => x.School);
            Map(x => x.GPA);
        }
    }
    public class TeacherMap : UserMap<Teacher>
    ...
