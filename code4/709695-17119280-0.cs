    `            MemberInfo[] members = Hook.MySql.GetType().GetMembers();
                foreach (MemberInfo member in members)
                {
                    if (member.MemberType == MemberTypes.Field) {
                        fi = (FieldInfo)member;
                        type = (fi).FieldType;
                        if (typeof(iSyncable).IsAssignableFrom(type))
                        {
                            dynamic cls = Activator.CreateInstance(type, Hook.MySql);
                            MemberInfo[] members2 = type.GetMembers();
                            type2 = null;
                            foreach (MemberInfo member2 in members2)
                            {
                                if (member2.Name == "Items")
                                {
                                    pi = (PropertyInfo)member2;
                                    type2 = pi.PropertyType;
                                    break;
                                }
                            }
                            if (type2 != null)
                            {
                                XML = clsXml.Serialize(fi.GetValue(Hook.MySql), cls.XMLParent, type2);
                            }
                        }
                    }
                }`
