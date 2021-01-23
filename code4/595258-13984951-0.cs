    var bench = XElement.Parse(@"<Contacts>
                    <Node>
                        Something
                    </Node>
                    <Node>
		Something else
                    </Node>
                    </Contacts>");
	
    var listOfNodes = bench.Elements();	
    listOfNodes.Dump();
	
    var content = listOfNodes.Select(x => x.Value);	
    content.Dump();
