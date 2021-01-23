    public class SchemaDescriptionUpdater<TContext> where TContext : DbContext
	{
		Type contextType;
		TContext context;
		DbTransaction transaction;
		XmlAnnotationReader reader;
		public SchemaDescriptionUpdater(TContext context)
		{
			this.context = context;
			reader = new XmlAnnotationReader();
		}
		public SchemaDescriptionUpdater(TContext context, string xmlDocumentationPath)
		{
			this.context = context;
			reader = new XmlAnnotationReader(xmlDocumentationPath);
		}
		public void UpdateDatabaseDescriptions()
		{
			contextType = typeof(TContext);
			var props = contextType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
			transaction = null;
			try
			{
				context.Database.Connection.Open();
				transaction = context.Database.Connection.BeginTransaction();
				foreach (var prop in props)
				{
					if (prop.PropertyType.InheritsOrImplements((typeof(DbSet<>))))
					{
						var tableType = prop.PropertyType.GetGenericArguments()[0];
						SetTableDescriptions(tableType);
					}
				}
				transaction.Commit();
			}
			catch
			{
				if (transaction != null)
					transaction.Rollback();
				throw;
			}
			finally
			{
				if (context.Database.Connection.State == System.Data.ConnectionState.Open)
					context.Database.Connection.Close();
			}
		}
		private void SetTableDescriptions(Type tableType)
		{
			string fullTableName = context.GetTableName(tableType);
			Regex regex = new Regex(@"(\[\w+\]\.)?\[(?<table>.*)\]");
			Match match = regex.Match(fullTableName);
			string tableName;
			if (match.Success)
				tableName = match.Groups["table"].Value;
			else
				tableName = fullTableName;
			var tableAttrs = tableType.GetCustomAttributes(typeof(TableAttribute), false);
			if (tableAttrs.Length > 0)
				tableName = ((TableAttribute)tableAttrs[0]).Name;
			
			// set the description for the table
			string tableComment = reader.GetCommentsForResource(tableType, null, XmlResourceType.Type);
			if (!string.IsNullOrEmpty(tableComment))
				SetDescriptionForObject(tableName, null, tableComment);
			
			// get all of the documentation for each property/column
			ObjectDocumentation[] columnComments = reader.GetCommentsForResource(tableType);
			foreach (var column in columnComments)
			{
				SetDescriptionForObject(tableName, column.PropertyName, column.Documentation);
			}
		}
		private void SetDescriptionForObject(string tableName, string columnName, string description)
		{
			string strGetDesc = "";
			// determine if there is already an extended description
			if(string.IsNullOrEmpty(columnName))
				strGetDesc = "select [value] from fn_listextendedproperty('MS_Description','schema','dbo','table',N'" + tableName + "',null,null);";
			else
				strGetDesc = "select [value] from fn_listextendedproperty('MS_Description','schema','dbo','table',N'" + tableName + "','column',null) where objname = N'" + columnName + "';";
			var prevDesc = (string)RunSqlScalar(strGetDesc);
			
			var parameters = new List<SqlParameter>
			{
				new SqlParameter("@table", tableName),
				new SqlParameter("@desc", description)
			};
			// is it an update, or new?
			string funcName = "sp_addextendedproperty";
			if (!string.IsNullOrEmpty(prevDesc))
				funcName = "sp_updateextendedproperty";
			string query = @"EXEC " + funcName + @" @name = N'MS_Description', @value = @desc,@level0type = N'Schema', @level0name = 'dbo',@level1type = N'Table',  @level1name = @table";
			// if a column is specified, add a column description
			if (!string.IsNullOrEmpty(columnName))
			{
				parameters.Add(new SqlParameter("@column", columnName));
				query += ", @level2type = N'Column', @level2name = @column";
			}
			RunSql(query, parameters.ToArray());
		}
        DbCommand CreateCommand(string cmdText, params SqlParameter[] parameters)
        {
            var cmd = context.Database.Connection.CreateCommand();
            cmd.CommandText = cmdText;
            cmd.Transaction = transaction;
            foreach (var p in parameters)
                cmd.Parameters.Add(p);
            return cmd;
        }
        void RunSql(string cmdText, params SqlParameter[] parameters)
        {
            var cmd = CreateCommand(cmdText, parameters);
            cmd.ExecuteNonQuery();
        }
        object RunSqlScalar(string cmdText, params SqlParameter[] parameters)
        {
            var cmd = CreateCommand(cmdText, parameters);
            return cmd.ExecuteScalar();
        }
    }
	public static class ReflectionUtil
	{
		public static bool InheritsOrImplements(this Type child, Type parent)
		{
			parent = ResolveGenericTypeDefinition(parent);
			var currentChild = child.IsGenericType
								   ? child.GetGenericTypeDefinition()
								   : child;
			while (currentChild != typeof(object))
			{
				if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
					return true;
				currentChild = currentChild.BaseType != null
							   && currentChild.BaseType.IsGenericType
								   ? currentChild.BaseType.GetGenericTypeDefinition()
								   : currentChild.BaseType;
				if (currentChild == null)
					return false;
			}
			return false;
		}
		private static bool HasAnyInterfaces(Type parent, Type child)
		{
			return child.GetInterfaces()
				.Any(childInterface =>
				{
					var currentInterface = childInterface.IsGenericType
						? childInterface.GetGenericTypeDefinition()
						: childInterface;
					return currentInterface == parent;
				});
		}
		private static Type ResolveGenericTypeDefinition(Type parent)
		{
			var shouldUseGenericType = true;
			if (parent.IsGenericType && parent.GetGenericTypeDefinition() != parent)
				shouldUseGenericType = false;
			if (parent.IsGenericType && shouldUseGenericType)
				parent = parent.GetGenericTypeDefinition();
			return parent;
		}
	}
	public static class ContextExtensions
	{
		public static string GetTableName(this DbContext context, Type tableType)
		{
			MethodInfo method = typeof(ContextExtensions).GetMethod("GetTableName", new Type[] { typeof(DbContext) })
							 .MakeGenericMethod(new Type[] { tableType });
			return (string)method.Invoke(context, new object[] { context });
		}
		public static string GetTableName<T>(this DbContext context) where T : class
		{
			ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
			return objectContext.GetTableName<T>();
		}
		public static string GetTableName<T>(this ObjectContext context) where T : class
		{
			string sql = context.CreateObjectSet<T>().ToTraceString();
			Regex regex = new Regex("FROM (?<table>.*) AS");
			Match match = regex.Match(sql);
			string table = match.Groups["table"].Value;
			return table;
		}
	}
