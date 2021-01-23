    public class MyModel
    {
      [Required]
      public string Foo { get; set; }
      [Required]
      public string Bar { get; set; }
    }
    public class StepOneModel
    {
      [Required]
      public string Foo { get; set; }
    }
    public class StepTwoModel
    {
      // This really depends on the behaviour you want.
      // In this example, the model isn't persisted until
      // the last step, but you could equally well persist
      // the partial model server-side and just include a
      // key in subsequent wizard steps.
      [Required]
      public StepOneModel StepOne { get; set; }
      [Required]
      public string Bar { get; set; }
    }
