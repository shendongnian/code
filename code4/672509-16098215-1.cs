    var xml = @"	
    <root> 
	  <row> 
	    <linksclicked>http://www.examiner.com/</linksclicked> 
	    <clickedcount>34</clickedcount>
	  </row> 
	  <row> 
	    <linksclicked>http://www.sample123.com</linksclicked> 
	    <clickedcount>16</clickedcount>
	  </row> 
	  <row> 
	    <linksclicked>http://www.testing123.com</linksclicked> 
	    <clickedcount>14</clickedcount>
	  </row> 
	</root>";
    var xElems = XDocument.Parse(xmlString);
    var xRow = doc.Root.Elements("row");
    List<Row> rowList = (from rowTags in xRow
                         let clickCount = 0
                         let isClickCountOk = Int32.TryParse((rowTags.Element("clickedcount").Value, clickCount);
                         where !string.IsNullOrEmpty(rowTags.Element("linksclicked").Value) &&
                               !string.IsNullOrEmpty(rowTags.Element("clickedcount").Value)
                         select new Row()
                         {
                             linksclicked = rowTags.Element("linksclicked").Value,
                             clickedcount = clickCount 
                         }).ToList();
