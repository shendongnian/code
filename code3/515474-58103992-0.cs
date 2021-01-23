     XmlNodeList elemList = root.GetElementsByTagName("title");
     IEnumerator ienum = elemList.GetEnumerator();          
     while (ienum.MoveNext()) {   
       XmlNode title = (XmlNode) ienum.Current;
       Console.WriteLine(title.InnerText);
     }
