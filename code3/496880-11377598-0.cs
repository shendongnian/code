    public class CustomRequireHttpsAttribute : RequireHttpsAttribute
    {
        /* override appropriate method with preprocessor directives */
    }
    [CustomRequireHttps]
    public ActionResult Foo(string foo) { /* ... */ }
    [CustomRequireHttps]
    public ActionResult Bar(string bar) { /* ... */ }
