    public class Person : Entity, IPerson
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual IList<Role> Roles { get; protected set; }
        public Person()
        {
            Roles = new List<Role>();
        }
        public virtual void AddRole(Role role)
        {
            if (Roles.Contains(role)) return;
            role.Person = this;
            Roles.Add(role);
        }
        public virtual void RemoveRole(Role role)
        {
            if (!Roles.Contains(role)) return;
            role.Person = null;
            Roles.Remove(role);
        }
    }
    public interface IPerson
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        Int32 Id { get; }
    }
    public abstract class Role : Entity
    {
        public virtual Person Person { get; set; }
        public virtual string RoleName { get; protected set; }
    }
    public class User : Role
    {
        public virtual string LoginName { get; set; }
        public virtual string Password { get; set; }
    }
