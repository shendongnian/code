public static void ForEachXML<XmlNode>(this XmlNodeList nodeList, Action<XmlNode>action)
{
    foreach (XmlNode node in nodeList)
    {
        action(node);
    }
}
Method Call:      
xDoc.GetElementsByTagName("text").ForEachXML<XmlNode>(tweet => 
    {
        if (tweet.InnerText.Length > 0)
            MessageBox.Show(tweet.InnerText);
    });
