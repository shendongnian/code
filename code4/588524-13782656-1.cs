    this.ParserHTML.LoadHTMLPage("http://www.img.com.br/default.aspx");
                HtmlNodeCollection HtmlNodeCollectionResult = this.ParserHTML.GetNodesByExpression(Page.XPathExpression);
                
                if (HtmlNodeCollectionResult != null)
                {
                    foreach (HtmlNode NodeResult in HtmlNodeCollectionResult)
                    {
                        var src = NodeResult.Attributes["src"].Value;
                    }
                }
