        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement btnBrowse = wb.Document.GetElementById("fiPhoto");
            if (btnBrowse != null)
            {
                HtmlElement newbtn = wb.Document.CreateElement("input");
                newbtn.SetAttribute("id", "btnLoad");
                newbtn.SetAttribute("type", "button");
                newbtn.SetAttribute("value", "Load");
                newbtn.Click += new HtmlElementEventHandler(newbtn_Click);
                btnBrowse.Parent.AppendChild(newbtn);
                btnBrowse.Style = "display:none";
            }
            HtmlElementCollection forms = wb.Document.Forms;
            if (forms.Count > 0)
            {
                HtmlElement form = wb.Document.Forms[0];
                form.AttachEventHandler("onsubmit", delegate(object o, EventArgs arg)
                    {
                        FormToMultipartPostData postData = new FormToMultipartPostData(wb, form);
                        postData.AddFile("photo", photo);
                        postData.Submit();
                    });
            }
        }
        private void newbtn_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(this);
            frm.ShowDialog();
        }
