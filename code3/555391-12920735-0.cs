    public class UserGroup : Object
        {   // NO editing just add remove
            public User User { get; private set; }
            public Group Group { get; private set; }
            public override bool Equals(Object obj)
            {
                //Check for null and compare run-time types.
                if (obj == null || !(obj is UserGroup)) return false;
                UserGroup item = (UserGroup)obj;
                return (User.ID == item.User.ID && Group.ID == item.Group.ID);
            }
            public override int GetHashCode() { return (User.ID & 0xffff) + (Group.ID << 16); }
            public UserGroup(User user, Group group)
            { User = user; Group = group; }
        }
