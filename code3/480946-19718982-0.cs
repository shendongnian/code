    namespace TestPCLContent
    {
        public interface IContentProvider
        {
            string LoadContent(string relativePath);
        }
    }
    namespace TestPCLContent
    {
        public class TestPCLContent
        {
            private IContentProvider _ContentProvider;
            public IContentProvider ContentProvider
            {
                get
                {
                    return _ContentProvider;
                }
                set
                {
                    _ContentProvider = value;
                }
            }
            public string GetContent()
            {
                return _ContentProvider.LoadContent(@"Content\buildcontent.xml");
            }
        }
    }
