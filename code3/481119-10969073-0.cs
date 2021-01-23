    using System.Xml;
        XmlDocument myxml = new XmlDocument();
        myxml.Load("D:/sample.xml");//Load you xml file from you disk what you want to load
        string element_1 = myxml.GetElementsByTagName("Name")[0].InnerText;
        string element_2 = myxml.GetElementsByTagName("Value")[0].InnerText; 
        string element_3 = myxml.GetElementsByTagName("Value")[0].InnerText;
        string element_4 = myxml.GetElementsByTagName("Name")[1].InnerText;
        string element_5 = myxml.GetElementsByTagName("Value")[1].InnerText; 
        string element_6 = myxml.GetElementsByTagName("Value")[1].InnerText;
