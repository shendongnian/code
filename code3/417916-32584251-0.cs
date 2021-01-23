               object objMsg = null;
				try
				{
					objMsg
					   = Activator.CreateInstance(TypeAssist.GetTypeFromTypeName("myAssembly.objBO"));
					strResponse = (string)objMsg.GetType().InvokeMember("MyMethod", BindingFlags.Public
							| BindingFlags.Instance | BindingFlags.InvokeMethod, null, objMsg,
							new object[] { vxmlRequest.OuterXml });
				}				
				finally
				{
					if (objMsg!=null)
						((IDisposable)objMsg).Dispose();
				}
