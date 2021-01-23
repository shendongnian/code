    public class Model
    {
        public struct BreadCrumb
        {
            public string Title;
            public string Url;
        }
        public List<BreadCrumb> Breadcrumbs { get; set; }
    }
