    Document doc = XDocument.Load(path);
           XNamespace nsd = doc.Root.GetDefaultNamespace();
            var res = doc.Descendants(nsd +"response");                
            
            var filteredEle = new List<XElement>();
            
                        foreach (var ele in res)
                        {
                            if (CheckEle(ele,nsd))
                            {
                                filteredEle.Add(ele);
                            }
                        }    
         
        
        private bool CheckEle(XElement ele, XNamespace nsd)
            {
                return ele.Element(nsd + "propstat").Element(nsd + "status").Value != "HTTP/1.1 404 Not Found";
            }
