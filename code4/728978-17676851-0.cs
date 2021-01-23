    static T Convert<T>(string val)
	{
			Type destiny = typeof(T);
			// See if we can cast			
			try
			{
				return (T)(object)val;
			}
			catch { }
			// See if we can parse
			try
			{
				return (T)destiny.InvokeMember("Parse", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public, null, null, new object[] { val });
			}
			catch { }
			// See if we can convert
			try
			{
				Type convertType = typeof(Convert);
				return (T)convertType.InvokeMember("To" + destiny.Name, System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Public, null, null, new object[] { val });
			}
			catch { }
			// Give up
			return default(T);
		}
