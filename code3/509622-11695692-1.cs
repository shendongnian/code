    XDocument doc = XDocument.Load(path);
                var res = doc.Root.Elements("response");
    
                var filteredEle = new List<XElement>();
    
                foreach (var ele in res)
                {
                    if (CheckEle(ele))
                    {
                        filteredEle.Add(ele);
                    }
                }
    private bool CheckEle(XElement ele)
            {
                return ele.Element("propstat").Element("status").Value != "HTTP/1.1 404 Not Found";
            }
