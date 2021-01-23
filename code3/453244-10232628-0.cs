    public class Registration {
        [Key]
        public Int64 Id { get; set; }
        public DateTime CreationDateTime { get; set; }
        public VersionedString FirstName { get; set; }
        public Registration() {
            CreationDateTime = DateTime.Now;
        }
        public static Registration Create() {
            return new Registration {
                FirstName = new VersionedString()
            }
        }
    }
