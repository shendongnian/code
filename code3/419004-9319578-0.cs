    public static string GetStringEquiValentOFEnumFromString<T>(int enumVal)
		 where T : struct
		{
			if (Enum.IsDefined(typeof(T), enumVal))
			{
				return Enum.ToObject(typeof (T), enumVal).ToString();
			}
		}
