    public class Teacher : Person
    {
        [Key]
        public Guid TeacherID { get; set; }
        //...
        public string Name { get; set; }  // only for the test example below
        //...
        public virtual Account Account { get; set; }
    }
    public class Account
    {
        [Key]
        public Guid AccountID { get; set; }
        //...
        public string Name { get; set; }  // only for the test example below
        //...
        public virtual Teacher Teacher { get; set; }
    }
