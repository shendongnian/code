    public class MyModel
    {
       [RegularExpression(@"^[a-zA-Z''-'\s]{1,400}$", ErrorMessage = "Characters are not allowed.")]
       public string Message { get; set; }
    }
