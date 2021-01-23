		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			Type myTypeObj = Type.GetType("Settings");
			foreach (FieldInfo p in myTypeObj.GetFields())
			{
				Object value = p.GetValue(null);
				info.AddValue(p.Name, value, value.GetType());
			}
		}
