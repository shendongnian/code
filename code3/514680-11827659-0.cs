    public class Menu
    {
        public string Name { get; set; }
        public string Roles { get; set; }
        public List<Menu> Children { get; set; }
        /// <summary>
        /// Checks whether this object or any of its children are in the specified role
        /// </summary>        
        public bool InRole(string role)
        {
            if (role == null)
            {
                throw new ArgumentNullException("role");
            }
            var inRole = (this.Roles ?? String.Empty).Contains(role);
            if (!inRole & Children != null)
            {
                return Children.Any(child => child.InRole(role));
            }
            return inRole;
        }
    }
