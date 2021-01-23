				connString =
					rootWebConfig.ConnectionStrings.ConnectionStrings["NorthwindConnectionString"];
				if (connString != null)
					Console.WriteLine("Northwind connection string = \"{0}\"",
						connString.ConnectionString);
				else
					Console.WriteLine("No Northwind connection string");
			}
