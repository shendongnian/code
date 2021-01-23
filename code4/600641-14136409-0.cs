    var doc = new XmlDocument();
                        doc.Load(files);
    
                        foreach (XmlElement pointCoord in doc.SelectNodes("/Attachment"))
                        {
                            if(pointCoord!=null)
                            {
                               var valueOfElement=pointCoord.InnerText;
                            }
                        }
