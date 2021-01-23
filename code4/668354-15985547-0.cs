    //From.cs
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Html_Class _Html_Class = new Html_Class();
        private void Add_Element_Click(object sender, EventArgs e)
        {
            HtmlElement userelement = _Html_Class.Create_Tag("p");
            userelement.InnerText = "Something";
            _Html_Class.Addend_Child(userelement);
            var s = _Html_Class.Get_Source();
        }
    }
    //Html_Class.cs
    public class Html_Class
    {
        private WebBrowser wb = new WebBrowser();
       
        public Html_Class()
        {
           wb.DocumentText = "<HTML><HEADER><title>My Web-page</title></HEADER><BODY></BODY></HTML>";
        }
        public HtmlElement Create_Tag(string tagname)
        {
            return  wb.Document.CreateElement("tagname");
        }
        public void Addend_Child(HtmlElement element)
        {
            wb.Document.Body.AppendChild(element);
        }
        public string Get_Source()
        {
         return (wb.Document.DomDocument as mshtml.HTMLDocument).documentElement.outerHTML;
        }
    }
