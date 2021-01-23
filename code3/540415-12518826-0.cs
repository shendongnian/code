	class Rule
	{	  
	  public string Name { get; set; }	  
	  public string Parameters { get; set; }
	}
	class XmlRule
	{
	  [XmlElement("Name")]
	  public string Name { get; set; }
	  [XmlElement("Parameters")]
	  public Parameters Parameters { get; set; }
	}
	class XmlParameters
	{
	   [XmlElement("User")]
	   public string User { get; set; }
	   [XmlElement("Database")]
	   public string Database { get; set; }
	}
	
	public Rule CreateRule(string xml)
	{
		XmlRule xmlRule = Deserialize(xml); // deserialize as you would do usually
		Rule result = new Rule
		{
			Name = xmlRule.Name,
			Parameters = CreateParametersXml(xmlRule.Parameters)
		};
		
		return result;
	}
	
	private string CreateParametersXml(XmlParameters parameters)
	{
		return string.Format("<User>{0}</User><Database>{1}</Database>",
							 parameters.User,
							 parameters.Database);
	}
