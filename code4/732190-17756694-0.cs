    var userSought = "userA";
    var passwordSought = "1234";
    
    XDocument xml = new XDocument(
    	new XDeclaration("1.0", "utf-8", "yes"),
    	new XElement("Users",
    		new XElement("User",
    			new XElement("Username", "Admin"),
    			new XElement("Password", "123")),
    		new XElement("User",
    			new XElement("Username", "userA"),
    			new XElement("Password", "123"))
    		));
    
    var userMatch = (from userElement in xml.Element("Users").Elements("User")
                      where userElement.Element("Username").Value == userSought
    				  select new
    				  {
    				      Username = userElement.Element("Username").Value,
    					  Password = userElement.Element("Password").Value
    				  }).FirstOrDefault();
    
    if(userMatch.Username == userSought && userMatch.Password == passwordSought)
    	Console.WriteLine(userSought + " matches password " + passwordSought);
    else
    	Console.WriteLine(userSought + " has password " + userMatch.Password + " but is expected to be " + passwordSought);
