public static IDbConnection GetConnection(DSRefNavigator navigator, out string type)
		{
			type = null;
			try
			{
				if (navigator != null)
				{
					IVsDataConnectionsService dataConnectionsService =
						(IVsDataConnectionsService) Package.GetGlobalService(typeof(IVsDataConnectionsService));
					string itemName = navigator.GetConnectionName();
					if (itemName != null)
					{
						int iConn; // = dataConnectionsService.GetConnectionIndex(itemName);
						DataViewHierarchyAccessor dataViewHierarchy = null;
						for(iConn = 0; iConn < dataConnectionsService.Count; iConn++)
						{
							DataViewHierarchyAccessor hierarchyAccessor =
								new DataViewHierarchyAccessor((IVsUIHierarchy) dataConnectionsService.GetConnectionHierarchy(iConn));
							try
							{
								if (hierarchyAccessor.Connection.DisplayConnectionString == itemName)
								{
									dataViewHierarchy = hierarchyAccessor;
									break;
								}
							}
							catch
							{
							}
						}
						if (dataViewHierarchy != null)
						{
							DataConnection connection = dataViewHierarchy.Connection;
							if (connection != null && connection.ConnectionSupport.ProviderObject != null)
							{
								type = connection.ConnectionSupport.ProviderObject.GetType().FullName;
								return (IDbConnection) connection.ConnectionSupport.ProviderObject;
							}
						}
					}
				}
			}
			catch
			{
			}
			return null;
		}
