    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;
    using System.Linq.Expressions;
    
    namespace ExpTest
    {
    	class Program
    	{
    		public class Mapping<T>
    		{
    			public Mapping(string fieldname, SqlParameter sqlParameter, Action<T, SqlParameter> assigner)
    			{
    				FieldName = fieldname;
    				SqlParameter = sqlParameter;
    				SqlParameterAssignment = assigner;
    			}
    			public string FieldName { get; private set; }
    			public SqlParameter SqlParameter { get; private set; }
    			public Action<T, SqlParameter> SqlParameterAssignment { get; private set; }
    		}
    
    		public class Mapper<T>
    		{
    			public IEnumerable<Mapping<T>> GetMappingElements()
    			{
    				foreach (var reflectionProperty in typeof(T).GetProperties())
    				{
    					// Input parameters to the created assignment action
    					var accessor = Expression.Parameter(typeof(T), "input");
    					var sqlParmAccessor = Expression.Parameter(typeof(SqlParameter), "sqlParm");
    
    					// Access the property (compiled later, but use reflection to locate property)
    					var property = Expression.Property(accessor, reflectionProperty);
    
    					// Cast the property to ensure it is assignable to SqlProperty.Value 
    					// Should contain branching for DBNull.Value when property == null
    					var castPropertyToObject = Expression.Convert(property, typeof(object));
    
    					// The sql parameter
    					var sqlParm = new SqlParameter(reflectionProperty.Name, null);
    
    					// input parameter for assignment action
    					var sqlValueProp = Expression.Property(sqlParmAccessor, "Value");
    
    					// Expression assigning the retrieved property from input object 
    					// to the sql parameters 'Value' property
    					var assign = Expression.Assign(sqlValueProp, castPropertyToObject);
    
    					// Compile into action (removes reflection and makes real CLR object)
    					var assigner = Expression.Lambda<Action<T, SqlParameter>>(assign, accessor, sqlParmAccessor).Compile();
    
    					yield return
    						new Mapping<T>(reflectionProperty.Name, // Table name
    							sqlParm, // The constructed sql parameter
    							assigner); // The action assigning from the input <T> 
    
    				}
    			}
    		}
    
    		public static void Main(string[] args)
    		{
    			var sqlStuff = (new Mapper<Data>().GetMappingElements()).ToList();
    
    			var sqlFieldsList = string.Join(", ", sqlStuff.Select(x => x.FieldName));
    			var sqlValuesList = string.Join(", ", sqlStuff.Select(x => '@' + x.SqlParameter.ParameterName));
    
    			var sqlStmt = string.Format("INSERT INTO test ({0}) VALUES ({1})", sqlFieldsList, sqlValuesList);
    
    			var dataObjects = Enumerable.Range(1, 100000).Select(id => new Data { Foo = 1.0 / id, ID = id, Title = "Title " + id });
    
    			var sw = Stopwatch.StartNew();
    
    			using (SqlConnection cnn = new SqlConnection(@"server=.\sqlexpress;database=test;integrated security=SSPI"))
    			{
    				cnn.Open();
    
    				SqlCommand cmd = new SqlCommand(sqlStmt, cnn);
    				cmd.Parameters.AddRange(sqlStuff.Select(x => x.SqlParameter).ToArray());
    
    				dataObjects.ToList()
    					.ForEach(dto =>
    						{
    							sqlStuff.ForEach(x => x.SqlParameterAssignment(dto, x.SqlParameter));
    							cmd.ExecuteNonQuery();
    						});
    			}
    
    
    			Console.WriteLine("Done in: " + sw.Elapsed);
    		}
    	}
    
    	public class Data
    	{
    		public string Title { get; set; }
    		public int ID { get; set; }
    		public double Foo { get; set; }
    	}
    }
