    public class A  // Base layer
    {
        protected static string token = "base class token";
    }
    public class B : A // First Level layer
    {
    }
    public class Main : B  // Second level layer
    {
       public string GetFromBase()
        {
            return A.token;
        }
    }
