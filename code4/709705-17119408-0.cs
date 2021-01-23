		public object Clone()
		{ 
			using (MemoryStream ms = new MemoryStream())
			{
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(ms, this);
				ms.Position = 0;
				return formatter.Deserialize(ms);
			}
		}
 
