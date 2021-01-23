    public partial class TestPage: UserControl
    {
        public TestPage()
        {
            InitializeComponent(); 
            MyClass myObject = new MyClass();
            myObject.SomeMember = "TEST";
            HtmlPage.Window.Invoke("JSFunction", myObject);
        }        
    }
