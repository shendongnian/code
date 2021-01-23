    public class MyModel
    {
      [Required]
      public string Foo { get; set; } // Populated in step 1
      [Required]
      public string Bar { get; set; } // Populated in step 2
    }
You have a problem when you POST step 1 because the user hasn't entered a value for Bar yet, so there's a ModelStateError.
