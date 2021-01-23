    internal class MyResources
    {
        // other properties etc
        internal static string SomeLabel 
        {
            get
            {
                return ResourceManager.GetString("SomeLabel", resourceCulture);
            }
        }
    }
