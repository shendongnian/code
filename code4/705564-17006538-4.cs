    interface IFoo
    {
       [Required]
       string Bar { get; set; }
    }
    
    interface IBar
    {
       string Bar { get; set; }
    }
    
    class Foo : IFoo, IBar
    {
       public string Bar { get; set; }
    }
