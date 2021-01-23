            MemberInfo[] memberInfos = dotNetType.GetMembers();
            ModelPropertySpec modelPropertySpec;
            foreach (MemberInfo memberInfo in memberInfos)
            {
                Type itemType = null;
                String memberName = memberInfo.Name;
                switch (memberInfo.MemberType)
                {
                    case MemberTypes.Property:
                        itemType = dotNetType.GetProperty(memberName).PropertyType;
                        break;
                    case MemberTypes.Field:
                        itemType = dotNetType.GetField(memberName).FieldType;
                        break;
                }
                if (itemType != null)
                {
                    modelPropertySpec = ParsePropertyType(memberName, itemType);
                    modelSpec.Properties.Add(modelPropertySpec.Name, modelPropertySpec);
                }
            }
