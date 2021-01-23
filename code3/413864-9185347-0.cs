	namespace WebBrowserEventTest
	{
		public partial class Form1 : Form
		{
			public Form1()
			{
				InitializeComponent();
				webBrowserTest.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(webBrowserTest_DocumentCompleted);
				webBrowserTest.Navigate("http://mondotees.com");
			}
			private void webBrowserTest_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
			{
				foreach(HtmlElement el in webBrowserTest.Document.GetElementsByTagName("div"))
				{
					el.AttachEventHandler("onpropertychange", delegate { testEventHandler(el, EventArgs.Empty); });
				}
				foreach (HtmlElement el in webBrowserTest.Document.GetElementsByTagName("div"))
				{
					el.Name = "test";
				}
			}
			public void testEventHandler(object sender, EventArgs e)
			{
				var he = (HtmlElement)sender;
			}
		}
	}
