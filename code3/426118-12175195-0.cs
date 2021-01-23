    public class User
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        #region Remappings
        public int UserId
        {
            get { return Id; }
            set { Id = value; }
        }
        #endregion
    }
