      private void Form1_Load_1(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = "<html><body></img></body></html>";
        }
        private void insert_image_btn_Click(object sender, EventArgs e)
        {
            HtmlElement userimage = webBrowser1.Document.CreateElement("img");
            userimage.SetAttribute("src", "image location");
            userimage.Id = "imageid";
            webBrowser1.Document.Body.AppendChild(userimage);
        }
        private void btn_set_aliign_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.GetElementById("imageid").SetAttribute("float", "right");
        }
