	var accounts = (from xElem in xDoc.Descendants("account")
	                select new Account()
				    {
					    Name = xElem.Element("name").Value ?? string.Empty,
						Password = xElem.Element("password").Value ?? string.Empty,
						Description = xElem.Element("description").Value ?? string.Empty
				    }).ToList();
