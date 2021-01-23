    private void b_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser b = sender as WebBrowser;
         if(b.Url.AbsoluteUri == "mydomain.com/page1.html")
         {
            string response = "";
            response = b.DocumentText;
            HtmlElement links = b.Document.GetElementById("btn1");
            links.InvokeMember("click");
            checkTrafiicButtonClick = true;
            MessageBox.Show("");
            return;
         }
            ***// upto these working and loading second page after that i want to fill data   
               and want to submit but down line is not working and it should be work after    
               loading the page that i submitted how can i do these***
         if(b.Url.AbsoluteUri == "mydomain.com//page2.htm")
         {
            HtmlElement tfrno = b.Document.GetElementById("TrfNo");
            tfrno.SetAttribute("value", "50012079");
            HtmlElement submitButon = b.Document.GetElementById("submitBttn");
            submitButon.InvokeMember("click");
            return;
         }
        }
