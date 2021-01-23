    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            //Navibate To your url
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Navigate("http://en.wikipedia.org/wiki/Microsoft");
            }
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                //Get header of subject
                foreach (HtmlElement elementintable in webBrowser1.Document.GetElementById("toc").All)
                {
                    if (elementintable.TagName == "A")
                    {
                        //insert key and string to each node
                        treeView1.Nodes.Add(elementintable.GetAttribute("href").Split('#')[1], elementintable.InnerText);
                    }
                }
            }
    
            private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
            {
                //navigate to selected anchor
                webBrowser1.Document.GetElementById(e.Node.Name).ScrollIntoView(true);
            }
        }
