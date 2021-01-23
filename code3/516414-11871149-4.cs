    public class ContentViewModel 
    {
        public List<User> Users { get; set; }
        public int TotalHours
        {
            get
            {
                return Users.Sum(u => u.Hours); // Assuming User has an Hours property
            }
        }
    }
