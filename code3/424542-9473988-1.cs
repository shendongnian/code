    public partial class MyClass
    {
        partial void ValidateMyProperty(ref string error)
        {
            if (MyProperty < 0)
                error = "MyProperty cannot be negative.";
        }
    }
