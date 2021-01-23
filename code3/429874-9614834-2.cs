	XDocument doc = new XDocument(
		new XDeclaration("1.0", "utf-8", "yes"),
		new XComment(""),
		new XElement("Snacks",
			trashFoods.Select(snack =>
				snack.Type=="Doritos" ? 
					new XElement("Snack",
						new XElement("Type", snack.Type),
						new XElement("Name", snack.Name),
						new XElement("GotSauce", snack.Sauce)) :
					new XElement("Snack",
						new XElement("Type", snack.Type),
						new XElement("Name", snack.Name))					
				)
			)
		);
