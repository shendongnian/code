			XmlRawTextWriter rawWriter = new XmlRawTextWriter(thisFilespec, Encoding.UTF8);
			rawWriter.Formatting = Formatting.Indented;
			rawWriter.Indentation = 1;
			rawWriter.IndentChar = '\t';
			xmlDoc.Save(rawWriter);
