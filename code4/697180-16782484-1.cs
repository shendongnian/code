	var doc = XElement.Parse(@"<result>
	<status>1</status>
	<qualities>
		<Normal>0</Normal>
		<rarity1>1</rarity1>
		<rarity2>2</rarity2>
		<vintage>3</vintage>
		<rarity3>4</rarity3>
		<rarity4>5</rarity4>
	</qualities>
	<qualityNames>
		<Normal>Normal</Normal>
		<rarity1>Genuine</rarity1>
		<rarity2>rarity2</rarity2>
		<vintage>Vintage</vintage>
		<rarity3>amazingrarity</rarity3>
		<rarity4>Unusual</rarity4>
	</qualityNames>
	</result>");
	
	var query = from quality in doc.XPathSelectElements("qualities/*")
				join qualityName in doc.XPathSelectElements("qualityNames/*")
				on quality.Name equals qualityName.Name
				select new { Key = quality.Value, Value = qualityName.Value };
	var qualities = query.ToDictionary(a => a.Key, a => a.Value);
	var quality3 = qualities["3"];
	// quality3 == "Vintage"
	var quality4 = qualities["4"];
	// quality4 == "amazingrarity"
