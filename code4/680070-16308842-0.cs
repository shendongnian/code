            HtmlElementCollection hc = webBrowser1.Document.GetElementsByTagName("a");
            for (int i = 0; i < hc.Count; i++)
            {
                if (hc[i].GetAttribute("href") == "name")
                    listBox1.Items.Add(hc[i].InnerHtml);// Or InnerText
            }
