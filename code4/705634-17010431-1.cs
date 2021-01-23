     HtmlAgilityPack.HtmlNodeCollection seResultsDivsColl = bodyNode.SelectNodes("//div[@class='sa_mc']");
                _Globals.Clientsdata.counterinner = 0;
                foreach (var ClientSeRes in seResultsDivsColl)
                {
                        _Globals.Clientsdata.info.SePhraseUsed = bodyNode.SelectSingleNode("//div[@id='DivSearchResWraper']").GetAttributeValue("title", "");
                        _Globals.Clientsdata.info.title = ClientSeRes.SelectSingleNode("//a").InnerText;
                        _Globals.Clientsdata.info.URL = ClientSeRes.SelectSingleNode("//a").Attributes["href"].Value;
                        _Globals.Clientsdata.info.ResultText = ClientSeRes.SelectSingleNode("//div[@class='Div_srParagraph_CssClss']").InnerText;
                                                  //  this is what i was missing out    //
                        _Globals.Clientsdata.info.ResultHTML = ClientSeRes.OuterHtml.Replace("'", "&#39;");
                        _Globals.Clientsdata.info.Mail = ClientSeRes.SelectSingleNode("//div[@class='Div_srMail_CssClss']/a[@href]").Attributes[0].Value.Replace("mailto: ", "");
                }
