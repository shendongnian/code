            void Document_Click(object sender, HtmlElementEventArgs e)
            {
               //Check Element is Button 
               if (webBrowser1.Document.ActiveElement.TagName == "BUTTON")
               {
                MessageBox.Show(webBrowser1.Document.ActiveElement.Id);
               }
            }
