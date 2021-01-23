	var list = docs.Descendants(name)
		 		   .Select(x => new
						{
						    Title = (string)x.Element(ns + "TITLE"),
						    Status = (string)x.Element(ns + "STATUS"),
						    PubEnd = (string)x.Element(ns + "PUB_END")
						})
				   .OrderByDescending(x => x.PubEnd).Take(20).ToList();
				
