    [DataContract]
    public class Relation
    {
        [Key, DataMember]
        public int ID { get; set; }
        [DataMember]
        public virtual ICollection<Person> People { get; set; }      
      
        [DataMember]
        public virtual ICollection<User> Users
        {
            get
            {
                return People.OfType<User>();
            }
        }
        [DataMember]
        public virtual ICollection<Driver> Drivers
        {
            get
            {
                return People.OfType<Driver>();
            }
        }
    }
