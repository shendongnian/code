        public void SetComboItem(string id, string value) {
            HtmlElement ee = this.webBrowser1.Document.GetElementById(id);
            foreach (HtmlElement item in ee.Children) {
                if (item.OuterHtml.ToLower().IndexOf(value.ToLower()) >= 0) {
                    item.SetAttribute("selected", "selected");
                    item.InvokeMember("onChange");
                }
                else {
                    item.SetAttribute("selected", "");
                }
            }
            ee = this.webBrowser1.Document.GetElementById(id + "-input");
            ee.InnerText = value;
        }
