		public void ReadXml(XmlReader reader)
		{
			string data = null;
			reader.MoveToAttribute("Color");
			if (reader.ReadAttributeValue())
			{
				data = reader.Value;
			}
			reader.ReadEndElement();
			var split = data.Split(' ');
			R = int.Parse(split[0]);
			G = int.Parse(split[1]);
			B = int.Parse(split[2]);
		}
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("Color", R + " " + G + " " + B);
		}
