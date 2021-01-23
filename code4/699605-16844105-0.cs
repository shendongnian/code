    public class ParentViewModel
    {
          public string SomeSharedField { get; set; }
    }
    public class ChildViewModel : ParentViewModel
    {
          public string SomeFieldJustForChild { get; set; }
    }
