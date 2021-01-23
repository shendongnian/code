    var xDoc    = XDocument.Load(openFileDialog1.FileName);
    //Use code below if you'll use string to Load XDocument
    /*var xmlString = @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
	<DataList>
		<Data>
			<ID>1</ID>
			<Name>Mike</Name>
			<Age>23</Age>
		</Data> 
		<Data>
			<ID>1</ID>
			<Name>Mike</Name>
			<Age>23</Age>
		</Data>
		<Data>
			<ID>1</ID>
			<Name>Mike</Name>
			<Age>23</Age>
		</Data>
		<Data></Data> continued...
	</DataList>
	";
	
	var xDoc     = XElement.Parse(xmlString);*/
	var dataList = xDoc.Descendants(@"Data");	
	var newXDoc  = new XDocument(new XDeclaration(null, null, null),
	                   new XElement("MainInterface",
					       new XElement("DataList",
						       dataList.Select(data =>
						           new XElement("Data",
								       data.Element("ID"),
									   data.Element("Name"),
									   data.Element("Age")
								   )
						       ) 
						   )					          
					   )
	               );
