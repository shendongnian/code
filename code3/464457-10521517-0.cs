    		MemberInfo[] members = obj.GetType().GetMethods();
			foreach (MemberInfo m in members)
			{
				if (m.MemberType == MemberTypes.Method)
				{
					MethodInfo p = m as MethodInfo;
					object[] attribs = p.GetCustomAttributes(false);
					foreach (object attr in attribs)
					{
						XYZ v = attr as XYZ;
						if (v != null)
							DoSomething();
					}
				}
			}
