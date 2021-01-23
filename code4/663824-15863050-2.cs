    [Table]
    public class UserAccount
    {
        ...
        [Column]
        private string rawRoles;
        public IEnumerable<int> Roles
        {
            get 
            {
                return (this.rawRoles == null) 
                    ? return new int[0] : 
                    : this.rawRoles.Split(",").Select(s => int.Parse(s));
            }
            set 
            {
                this.rawRoles = (value == null)
                    ? null
                    : String.Join(",", value);
            }
        }
    }
