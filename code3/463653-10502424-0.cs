			MemberInfo[] members = builder.GetType().GetProperties();
			foreach (MemberInfo m in members)
			{
				if (m.MemberType == MemberTypes.Property)
				{
					PropertyInfo p = m as PropertyInfo;
					object[] attribs = p.GetCustomAttributes(false);
					foreach (object attr in attribs)
					{
						IssuerDesigner d = attr as IssuerDesigner;
						if (d != null)
						{
                            foreach(object obj in d.Issuer)
                            {
                                 DoSomething(obj);
                            }
                    	}
                    }
				}
			}
