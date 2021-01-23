    List<string> stopIdList = new List<string>();
    
    foreach (XmlNode stopIdNode 
             in xmlDoc.SelectNodes
             ("/ArrayOfStop/Stop[StopName='Cysleys Farm (by request only)']/stopId"))
    {
        stopIdList.Add(stopIdNode.InnerText);
    }
