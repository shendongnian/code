		    System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
				doc.LoadXml(yourXmlString);            
				if (doc.HasChildNodes)
				{
				System.Xml.XmlNodeList jobLst = doc.DocumentElement.ChildNodes;
				System.Collections.Generic.Dictionary<string, string> jobDescription;
				var lstjobDescription = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, string>>();
				string name;
				for (int i = 0; i < jobLst.Count; i++)
				{
				var responseDoc = new System.Xml.XmlDocument();
				responseDoc.LoadXml(jobLst[i].OuterXml);
				jobDescription = new System.Collections.Generic.Dictionary<string, string>();
				foreach (System.Xml.XmlNode node in responseDoc.SelectNodes("//job/*")) //select all nodes of Job
				{                
				jobDescription.Add(node.Name, node.InnerText);
				}
				lstjobDescription.Add(jobDescription);                       
				}
				}        
