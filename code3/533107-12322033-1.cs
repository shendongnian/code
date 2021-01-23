    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Clear();
            bundles.ResetAll();
            BundleTable.EnableOptimizations = false;
    
            bundles.Add(...);
        }
    }
