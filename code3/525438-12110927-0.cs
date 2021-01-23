    public partial class TestPage: UserControl
    {
        public TestPage()
        {
            InitializeComponent(); 
            int i = 1;
            HtmlPage.Window.Invoke("JSFunction", i);
        }        
    }
