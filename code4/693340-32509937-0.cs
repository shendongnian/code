    [Table("TestModels")]
    public class TestModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Some", Description = "desc")]
        [Unique(ErrorMessage = "This already exist !!")]
        public string SomeThing { get; set; }
    }
