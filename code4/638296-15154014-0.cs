     System.Configuration.Configuration rootWebConfig =
				System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
			System.Configuration.ConnectionStringSettings connString;
			if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
			{
				connString =
					rootWebConfig.ConnectionStrings.ConnectionStrings["NorthwindConnectionString"];
				if (connString != null)
					Console.WriteLine("Northwind connection string = \"{0}\"",
						connString.ConnectionString);
				else
					Console.WriteLine("No Northwind connection string");
			}
