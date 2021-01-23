            foreach (System.Reflection.MemberInfo oMember in this.GetType().GetMembers())
            {
                switch (oMember.MemberType)
                {
                    case System.Reflection.MemberTypes.Field:
                        var oField = (System.Reflection.FieldInfo)oMember;
                        Console.WriteLine(oField.Name + " = " + oField.GetValue(this).ToString());
                        break;
                    case System.Reflection.MemberTypes.Property:
                        var oProperty = (System.Reflection.PropertyInfo)oMember;
                        Console.WriteLine(oProperty.Name + " = " + oProperty.GetValue(this, null).ToString());
                        break;
                }
            }
