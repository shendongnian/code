    public class MyClass
    {
        [Key]
        public int MyClassId { get; set; }
        public string Data { get; set; }
        public virtual Classes Classes { get; set; }
    }
    public class Classes
    {
        [Key]
        public int ClassesId { get; set; }
        [Required]
        public int MyClassId { get; set; }
        public List<MyClass> Classes { get; set; }
        [Required]
        public virtual MyClass MyClass { get; set; }
    }
