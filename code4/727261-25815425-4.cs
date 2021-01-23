    public class ParentDTO
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        /* here you just have the primitive types or other DTOs, 
           do not reference any Entity type*/
    }
