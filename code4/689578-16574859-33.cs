	public interface ICommandBuilder
	{
		string InsertSql { get; }
		string UpdateSql { get; }
		string DeleteSql { get; }
		Dictionary<string, object> InsertParameters(object data);
		Dictionary<string, object> UpdateParameters(object data);
		Dictionary<string, object> DeleteParameters(object data);
	}
	public class CommandBuilder: ICommandBuilder
	{
		private readonly IDbMapping mapping;
		private readonly Dictionary<string, object> fieldParameters;
		private readonly Dictionary<string, object> keyParameters; 
		public CommandBuilder(IDbMapping mapping)
		{
			this.mapping = mapping;
			fieldParameters = new Dictionary<string, object>();
			keyParameters = new Dictionary<string, object>();
			GenerateBaseSqlAndParams();
		}
		private void GenerateBaseSqlAndParams()
		{
			var updateSb = new StringBuilder();
			var insertSb = new StringBuilder();
			var whereClause = new StringBuilder(" WHERE ");
			updateSb.Append("Update " + mapping.TableName + " SET ");
			insertSb.Append("Insert Into " + mapping.TableName + " VALUES (");
			var properties = mapping.EntityType.GetProperties(); // if you have mappings, work that in
			foreach (var propertyInfo in properties)
			{
				var paramName = propertyInfo.Name;
				if (mapping.Keys.Contains(propertyInfo.Name, StringComparer.OrdinalIgnoreCase))
				{
					keyParameters.Add(paramName, null);
					if (!mapping.AutoGenerateIds)
					{
						insertSb.Append(paramName + ", ");
					}
					whereClause.Append(paramName + " = @" + paramName);
				}
				updateSb.Append(propertyInfo.Name + " = @" + paramName + ", ");
				fieldParameters.Add(paramName, null);
			}
			updateSb.Remove(updateSb.Length - 2, 2); // remove the last ","
			insertSb.Remove(insertSb.Length - 2, 2);
			insertSb.Append(" )");
			this.InsertSql = insertSb.ToString();
			this.UpdateSql = updateSb.ToString() + whereClause;
			this.DeleteSql = "DELETE FROM " + mapping.TableName + whereClause;
		}
		public string InsertSql { get; private set; }
		public string UpdateSql { get; private set; }
		public string DeleteSql { get; private set; }
		public Dictionary<string, object> InsertParameters(object data)
		{
			PopulateParamValues(data);
			return mapping.AutoGenerateIds ? fieldParameters : keyParameters.Union(fieldParameters).ToDictionary(pair => pair.Key, pair => pair.Value);
		}
		public Dictionary<string, object> UpdateParameters(object data)
		{
			PopulateParamValues(data);
			return fieldParameters.Union(keyParameters).ToDictionary(pair => pair.Key, pair => pair.Value);
		}
		public Dictionary<string, object> DeleteParameters(object data)
		{
			PopulateParamValues(data);
			return keyParameters;
		}
		public void PopulateParamValues(object data)
		{
			var properties = mapping.EntityType.GetProperties(); // if you have mappings, work that in
			foreach (var propertyInfo in properties)
			{
				var paramName = propertyInfo.Name;
				if (keyParameters.ContainsKey(paramName))
				{
					keyParameters[paramName] = propertyInfo.GetValue(data);
				}
				if (fieldParameters.ContainsKey(paramName))
				{
					fieldParameters[paramName] = propertyInfo.GetValue(data);
				}
			}
		}
	}
