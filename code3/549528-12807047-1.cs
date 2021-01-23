    BusinessObjects.Attribute attribute = 
          db.Attributes.FirstOrDefault(a => a.attribute_id == AttributeID);
    string[] AttributeTags = 
          txtAttributeTags.Text.Split(new string[] { "," },
    StringSplitOptions.RemoveEmptyEntries);
	
    foreach (var item in from a in AttributeTags
	     where attribute.AttributeTags.Any(t => t.value == a)
	     select new AttributeTag 
	     { 
		value = item, 
		timestamp = DateTime.Now 
	     })
    attribute.AttributeTags.Add(item);
	
    foreach (var item in from a in attribute.AttributeTags
	     where AttributeTags.Any(t => t == a.value)
	     select a)
    attribute.AttributeTags.Remove(item);
		
    db.SaveChanges();
