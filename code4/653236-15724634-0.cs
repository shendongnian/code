    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            response.Content = Less.Parse(response.Content); // Breakpoint here.
            response.ContentType = "text/css";
        }
    }
