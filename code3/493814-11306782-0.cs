            string s = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?><expenses>    <country>        <name>Germany</name>        <ID>D</ID>        <_24h>42</_24h>        <_14h>28</_14h>        <_8h>14</_8h>        <overnight>100</overnight>    </country>    <country>        <name>India</name>        <ID>IND</ID>            <_24h>30</_24h>            <_14h>20</_14h>            <_8h>10</_8h>            <overnight>120</overnight></country></expenses>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(s);
            XmlNode rootNode = doc.SelectSingleNode(@"/expenses");
            var nodes24 = rootNode.SelectNodes(@"country/_24h");
            var nodes14 = rootNode.SelectNodes(@"country/_14h");
            List<string> twentyFour = new List<string>();
            twentyFour.AddRange(nodes24.Cast<XmlNode>().Select(i => i.InnerText).ToArray());
