    Interface IFoo
    {
       [Required]
       string Bar {get; set;}
    }
    
    Interface IBar
    {
       string Bar {get; set;}
    }
    
    Class Foo : IFoo, IBar
    {
       string Bar {get; set;}
    }
