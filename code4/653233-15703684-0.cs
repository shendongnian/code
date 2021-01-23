    public class LessTransform : IBundleTransform
    {
        void IBundleTransform.Process(BundleContext context, BundleResponse response)
        {
            response.Content = Less.Parse(response.Content);
            response.ContentType = "text/css";
        }
    }
