		public static object Parse(System.Type enumType, string value, bool ignoreCase)
		{
			//throw an exception on null value
			if(value.TrimEnd(' ')=="")
			{
				throw new ArgumentException("value is either an empty string (\"\") or only contains white space.");
			}
			else
			{
				//type must be a derivative of enum
				if(enumType.BaseType==Type.GetType("System.Enum"))
				{
					//remove all spaces
					string[] memberNames = value.Replace(" ","").Split(',');
					
					//collect the results
					//we are cheating and using a long regardless of the underlying type of the enum
					//this is so we can use ordinary operators to add up each value
					//I suspect there is a more efficient way of doing this - I will update the code if there is
					long returnVal = 0;
					//for each of the members, add numerical value to returnVal
					foreach(string thisMember in memberNames)
					{
						//skip this string segment if blank
						if(thisMember!="")
						{
							try
							{
								if(ignoreCase)
								{
									returnVal += (long)Convert.ChangeType(enumType.GetField(thisMember, BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase).GetValue(null),returnVal.GetType(), null);
								}
								else
								{
									returnVal += (long)Convert.ChangeType(enumType.GetField(thisMember, BindingFlags.Public | BindingFlags.Static).GetValue(null),returnVal.GetType(), null);
								}
							}
							catch
							{
								try
								{
									//try getting the numeric value supplied and converting it
									returnVal += (long)Convert.ChangeType(System.Enum.ToObject(enumType, Convert.ChangeType(thisMember, System.Enum.GetUnderlyingType(enumType), null)),typeof(long),null);
								}
								catch
								{
									throw new ArgumentException("value is a name, but not one of the named constants defined for the enumeration.");
								}
								//
							}
						}
					}
					//return the total converted back to the correct enum type
					return System.Enum.ToObject(enumType, returnVal);
				}
				else
				{
					//the type supplied does not derive from enum
					throw new ArgumentException("enumType parameter is not an System.Enum");
				}
			}
		}
