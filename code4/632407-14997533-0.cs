    public class User
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public List<Article> Article { get; set; }
        public String Surname { get; set; }
        public override string ToString()
        {
           return Id.ToString() + Name + Surname;
        }
    }
