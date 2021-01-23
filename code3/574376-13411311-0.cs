		public string Attribute1;
		public string Attribute2;
		public string Element1;
		public string Element2;
		public List<string> List1;
		public List<string> List2;
		
		public void ParseXDocument(string xml)
		{
			XNamespace xn = "somenamespace";            
			XDocument document = XDocument.Parse(xml);
		
			XElement elementRoot = document.Root;
			elementRoot.MatchElement(xn.GetName("object"), xObject => {
				xObject.MatchAttribute("attribute1", (x,a) => this.Attribute1 = (string)a);
				xObject.MatchAttribute("attribute2", (x,a) => this.Attribute2 = (string)a);
				xObject.MatchElement(xn.GetName("element1"), x => this.Element1 = (string)x);
				xObject.MatchElement(xn.GetName("element2"), x => this.Element2 = (string)x);
			});
		}
	}
