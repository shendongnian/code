            foreach (HtmlNode bevFactNode in bevFactsNodes)
            {
                HtmlNodeCollection childNodes = bevFactNode.ChildNodes;
                foreach (HtmlNode node in childNodes)
                {
                    foreach(HtmlNode subNode in node.ChildNodes)
                    {
                        if (subNode.InnerText.Trim() == "Årgång")
                            vintage = HttpUtility.HtmlDecode(subNode.NextSibling.NextSibling.InnerText.Trim());
                    }
                }
            }
            Console.WriteLine("Vintage: " + vintage);
