    static void Main(string[] args)
    {
        Foo();
    }
    
    [IgnoreMethod(IsIgnored=true)]
    public static void Foo()
    {
        Console.WriteLine("Executing Foo()...");
    }
    
    [Serializable]
    public class IgnoreMethodAttribute : PostSharp.Aspects.MethodInterceptionAspect
    {
        public bool IsIgnored { get; set; }
    
        public override void OnInvoke(PostSharp.Aspects.MethodInterceptionArgs args)
        {
            if (IsIgnored)
            {
                return;
            }
    
            base.OnInvoke(args);
        }
    }
