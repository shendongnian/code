    public class DateTimeDataContractSurrogate : IDataContractSurrogate
        {
            private static readonly Regex dateRegex = new Regex(@"/Date\((\d+)([-+])(\d+)\)/");
            private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            public object GetCustomDataToExport(Type clrType, Type dataContractType)
            {
                // not used
                return null;
            }
            public object GetCustomDataToExport(System.Reflection.MemberInfo memberInfo, Type dataContractType)
            {
                // not used
                return null;
            }
            public Type GetDataContractType(Type type)
            {
                // not used
                return type;
            }
            public object GetDeserializedObject(object obj, Type targetType)
            {
                // for debugging
                //Console.WriteLine("GetDeserializedObject: obj = {0} ({1}), targetType = {2}", obj, obj.GetType(), targetType);
                // only act on List<object> types
                if (obj.GetType() == typeof(List<object>))
                {
                    var objList = (List<object>)obj;
                    List<object> copyList = new List<object>(); // a list to copy values into. this will be the list returned.
                    foreach (var item in objList)
                    {
                        string s = item as string;
                        if (s != null)
                        {
                            // check if we match the DateTime format
                            Match match = dateRegex.Match(s);
                            if (match.Success)
                            {
                                // try to parse the string into a long. then create a datetime and convert to local time.
                                long msFromEpoch;
                                if (long.TryParse(match.Groups[1].Value, out msFromEpoch))
                                {
                                    TimeSpan fromEpoch = TimeSpan.FromMilliseconds(msFromEpoch);
                                    copyList.Add(TimeZoneInfo.ConvertTimeFromUtc(epoch.Add(fromEpoch), TimeZoneInfo.Local));
                                    continue;
                                }
                            }
                        }
                        copyList.Add(item); // add unmodified
                    }
                    return copyList;
                }
                return obj;
            }
            public void GetKnownCustomDataTypes(System.Collections.ObjectModel.Collection<Type> customDataTypes)
            {
                // not used   
            }
            public object GetObjectToSerialize(object obj, Type targetType)
            {
                // for debugging
                //Console.WriteLine("GetObjectToSerialize: obj = {0} ({1}), targetType = {2}", obj, obj.GetType(), targetType);
                return obj;
            }
            public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
            {
                // not used
                return null;
            }
            public System.CodeDom.CodeTypeDeclaration ProcessImportedType(System.CodeDom.CodeTypeDeclaration typeDeclaration, System.CodeDom.CodeCompileUnit compileUnit)
            {
                // not used
                return typeDeclaration;
            }
        }
