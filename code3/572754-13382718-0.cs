                       var h3s = browser.Div(Find.ById("ProdPrsnttnGrpCntnr")).ElementsWithTag("h3").ToArray();
                        for (int i = 1; i < h3s.Count(); i++)
                        {
                            h3s[i].Click();
                            System.Threading.Thread.Sleep(5000);
                            types = doc.DocumentNode.SelectNodes("//h3[@class='AbbrPrsnttn_PrsnttnNm']");
                            doc2.LoadHtml(browser.Html);
                            partTable = doc2.DocumentNode.SelectSingleNode("//div[@class='ItmTblGrp']");
                            MineNext(doc, doc2, browser, typeUrl, types, desc, partTable);
                            h3s = browser.Div(Find.ById("ProdPrsnttnGrpCntnr")).ElementsWithTag("h3").ToArray();
                        }
