    public class PluginAssembly
    {
        // (class code here)
        private sealed class CustomizedBinder : SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type returntype = null;
                if (typeName.StartsWith("NeededAssembly.RemoteClient.MessagePayload"))
                {
                    returntype = typeof(MessagePayload);
                }
                else if (typeName.StartsWith("NeededAssembly.RemoteClient.ResultsPayload"))
                {
                    returntype = typeof(ResultsPayload);
                }
                else if (typeName.Equals("System.Collections.Generic.List`1[[NeededAssembly.ShortResult, NeededAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]"))
                {
                    returntype = typeof(List<ShortResult>);
                }
                else
                {
                    returntype =
                            Type.GetType(String.Format("{0}, {1}",
                            typeName, assemblyName));
                }
                return returntype;
            }
            public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
            {
                base.BindToName(serializedType, out assemblyName, out typeName);
                if (serializedType.ToString().Contains("NeededAssembly"))
                {
                    assemblyName = typeof(MessagePayload).Assembly.FullName;
                }
            }
        }
    }
