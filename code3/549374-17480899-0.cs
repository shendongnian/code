		    builder.Register(c =>
		        {
		            var db = c.Resolve<MyDbContext>();
		            if (db.Database.Connection.State != ConnectionState.Open)
		            {
		                db.Database.Connection.Open();
		            }
		            return db.Database.Connection;
		        })
		           .As<IDbConnection>()
		           .ExternallyOwned() // DbContext owns connection and closes him when disposing.
		           .InstancePerHttpRequest();
