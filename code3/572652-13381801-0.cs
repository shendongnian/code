     //select connections node from loaded xml Excel
     csNode = xmlDoc.SelectSingleNode("*/*/*[@connection]");
     //store original node values
     oldConnValue = csNode.Attributes["connection"].Value;
     oldCommValue = csNode.Attributes["command"].Value;
     //delete existing ConnectionsPart - to ensure that bleed-over data is not present
     wkb.WorkbookPart.DeletePart(wkb.WorkbookPart.ConnectionsPart);
     //create a replacement ConnectionsPart
     wkb.WorkbookPart.AddNewPart<ConnectionsPart>();
     csNode.Attributes["connection"].Value = oldConnValue; //reassign existing connection value
     csNode.Attributes["command"].Value = baseQry;         //assign new query
     //save changes to stream
     xmlDoc.Save(wkb.WorkbookPart.ConnectionsPart.GetStream());
