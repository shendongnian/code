    public class MyPage
    {
        public MyPage()
        {
            Content = new MyData();
        }
        public MyData Content { get; set; }
    }
    public class MyData
    {
        public MyData()
        {
            Text = new Dictionary<string, string>();
        }
        public IDictionary<string, string> Text { get; private set; }
    }
