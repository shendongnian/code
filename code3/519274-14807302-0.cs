	public class DictionaryModelBinder : DefaultModelBinder
	{
		private const string _dateTimeFormat = "dd/MM/yyyy HH:mm:ss";
	 
		private enum StateMachine
		{
			NewSection,
			Key,
			Delimiter,
			Value,
			ValueArray
		}
	 
		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var stream = controllerContext.HttpContext.Request.InputStream;
			string text;
	 
			stream.Position = 0;
			using (var reader = new StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}
	 
			int index = 0;
			return Build(text, ref index);
		}
	 
		private static Dictionary<string, object> Build(string text, ref int index)
		{
			var state = StateMachine.NewSection;
			var dictionary = new Dictionary<string, object>();
			var key = string.Empty;
			object value = string.Empty;
	 
			for (; index < text.Length; ++index)
			{
				if (state == StateMachine.NewSection && text[index] == '{')
				{
					dictionary = new Dictionary<string, object>();
					state = StateMachine.NewSection;
				}
				else if (state == StateMachine.NewSection && text[index] == '"')
				{
					key = string.Empty;
					state = StateMachine.Key;
				}
				else if (state == StateMachine.Key && text[index] != '"')
				{
					key += text[index];
				}
				else if (state == StateMachine.Key && text[index] == '"')
				{
					state = StateMachine.Delimiter;
				}
				else if (state == StateMachine.Delimiter && text[index] == ':')
				{
					state = StateMachine.Value;
					value = string.Empty;
				}
				else if (state == StateMachine.Value && text[index] == '[')
				{
					state = StateMachine.ValueArray;
					value = value.ToString() + text[index];
				}
				else if (state == StateMachine.ValueArray && text[index] == ']')
				{
					state = StateMachine.Value;
					value = value.ToString() + text[index];
				}
				else if (state == StateMachine.Value && text[index] == '{')
				{
					value = Build(text, ref index);
				}
				else if (state == StateMachine.Value && text[index] == ',')
				{
					dictionary.Add(key, ConvertValue(value));
					state = StateMachine.NewSection;
				}
				else if (state == StateMachine.Value && text[index] == '}')
				{
					dictionary.Add(key, ConvertValue(value));
					return dictionary;
				}
				else if (state == StateMachine.Value || state == StateMachine.ValueArray)
				{
					value = value.ToString() + text[index];
				}
			}
	 
			return dictionary;
		}
	 
		private static object ConvertValue(object value)
		{
			string valueStr;
			if (value is Dictionary<string, object> || value == null || (valueStr = value.ToString()).Length == 0)
			{
				return value;
			}
	 
			bool boolValue;
			if (bool.TryParse(valueStr, out boolValue))
			{
				return boolValue;
			}
	 
			int intValue;
			if (int.TryParse(valueStr, out intValue))
			{
				return intValue;
			}
	 
			double doubleValue;
			if (double.TryParse(valueStr, out doubleValue))
			{
				return doubleValue;
			}
	 
			valueStr = valueStr.Trim('"');
	 
			DateTime datetimeValue;
			if (DateTime.TryParseExact(valueStr, _dateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out datetimeValue))
			{
				return datetimeValue;
			}
	 
			if (valueStr.First() == '[' && valueStr.Last() == ']')
			{
				valueStr = valueStr.Trim('[', ']');
				if (valueStr.Length > 0)
				{
					if (valueStr[0] == '"')
					{
						return valueStr
							.Split(new[] { '"' }, StringSplitOptions.RemoveEmptyEntries)
							.Where(x => x != ",")
							.ToArray();
					}
					else
					{
						return valueStr
							.Split(',')
							.Select(x => ConvertValue(x.Trim()))
							.ToArray();
					}
				}
			}
	 
			return valueStr;
		}
    }
	
