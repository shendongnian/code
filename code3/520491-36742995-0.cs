    public class OptimizedScriptBundle : ScriptBundle
    {
        public OptimizedScriptBundle(string virtualPath)
            : base(virtualPath)
        {
        }
    
        public OptimizedScriptBundle(string virtualPath, string cdnPath)
            : base(virtualPath, cdnPath)
        {
        }
    
        public override IEnumerable<BundleFile> EnumerateFiles(BundleContext context)
        {
            if (context.EnableOptimizations)
                return base.EnumerateFiles(context);
            try
            {
                context.EnableOptimizations = true;
                return base.EnumerateFiles(context);
            }
            finally
            {
                context.EnableOptimizations = false;
            }
        }
    }
