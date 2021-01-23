	var subsys = doc.Descendants("dataModule")
		            .Where(data => data.Element("system").Value == sys)
		            .Select(data => data.Element("subsystem").Value)
		            .Distinct();
    foreach (var mysub in subsys)
    {
        buildSubSystemNodes(sys, mysub);
        getUnits(sys, mysub); 
    }
