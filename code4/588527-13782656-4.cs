    this.ParserHTML.LoadHTMLPage("http://www.w3schools.com/tags/tag_img.asp");
                HtmlNodeCollection HtmlNodeCollectionResult = this.ParserHTML.GetNodesByExpression("//div[@class='tryit_ex'] //img");
                
                if (HtmlNodeCollectionResult != null)
                {
                    foreach (HtmlNode NodeResult in HtmlNodeCollectionResult)
                    {
                        var src = NodeResult.Attributes["src"].Value;
                        var w = NodeResult.Attributes["width"].Value;
                        var h = NodeResult.Attributes["height"].Value;
                    }
                }
