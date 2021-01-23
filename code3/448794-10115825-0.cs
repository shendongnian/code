    public class Person
    {
        [Range(1, int.MaxValue, ErrorMessage = "You have to identify yourself!!")]
        public int Id { get; set; }
        public decimal Age { get; set; }    
    }
