	string file = File.ReadAllText("a.html"); // gets the html
	CQ dom = file; // initializes csquery
	CQ td = dom["td"]; // get all td files
	td.Each((i,e) => { // go through each
		if (e.FirstChild != null) // if element has child (font)
		{
			if (e.FirstChild.NodeType != NodeType.TEXT_NODE) // ignore text node
			{
				if (e.FirstChild.InnerText == "1") // if number is 1
				{
					Console.WriteLine(e.NextElementSibling.InnerText); // output the text
				}
				if (e.FirstChild.InnerText == "8") // etc etc
				{
					Console.WriteLine(e.NextElementSibling.InnerText);
				}
			}
		}
		
	});
	Console.ReadKey();
