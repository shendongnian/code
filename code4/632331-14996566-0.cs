    private void Form1_Load(object sender, EventArgs e)
            {
                this.webBrowser1.Navigate("about:blank");
                this.webBrowser1.Document.Write("<INPUT id='hell' class='blah' placeholder='text here'   name='hell' type='text'></INPUT>");
                dynamic htmldoc = webBrowser1.Document.DomDocument as dynamic;
                dynamic node = htmldoc.getElementById("hell") as dynamic;
                string x = node.OuterHtml; //gets name but not type
                string s = node.GetAttribute["type"]; //gets type
                string name = node.GetAttribute["name"]; //gets name
            }
