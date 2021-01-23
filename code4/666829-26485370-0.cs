    public interface INullableOracleCustomType: INullable,  IOracleCustomType
    	{
    	}
    
    [OracleCustomTypeMapping("<YOUR_SCHEMA_NAME>.<UDT_OBJECT_NAME>")]
    	public class ParameterObject : INullableOracleCustomType
    	{
    		private bool objectIsNull;
    
    		#region constructor
    
    		public ParameterObject()
    		{ }
    
    		public ParameterObject(string parameterName, string parameterValue)
    		{
    			this.ParameterName = parameterName;
    			this.ParameterValue = parameterValue;
    		}
    
    		#endregion
    
    		#region properties
    		[OracleObjectMappingAttribute("PARAMETERNAME")]
    		public string ParameterName { get; set; }
    
    		[OracleObjectMappingAttribute("PARAMETERVALUE")]
    		public string ParameterValue { get; set; }
    
    		public static ParameterObject Null
    		{
    			get
    			{
    				ParameterObject parameterObject = new ParameterObject();
    				parameterObject.objectIsNull = true;
    				return parameterObject;
    			}
    		}
    
    		#endregion
    
    		#region INullable Members
    
    		public bool IsNull
    		{
    			get { return objectIsNull; }
    		}
    
    		#endregion
    
    		#region IOracleCustomType
    		public void FromCustomObject(Oracle.DataAccess.Client.OracleConnection con, IntPtr pUdt)
    		{
    			// Convert from the Custom Type to Oracle Object
    			if (!string.IsNullOrEmpty(ParameterName))
    			{
    				OracleUdt.SetValue(con, pUdt, "PARAMETERNAME", ParameterName);
    			}
    			if (!string.IsNullOrEmpty(ParameterValue))
    			{
    				OracleUdt.SetValue(con, pUdt, "PARAMETERVALUE", ParameterValue);
    			}
    		}
    
    		public void ToCustomObject(Oracle.DataAccess.Client.OracleConnection con, IntPtr pUdt)
    		{
    			ParameterName = (string)OracleUdt.GetValue(con, pUdt, "PARAMETERNAME");
    			ParameterValue = (string)OracleUdt.GetValue(con, pUdt, "PARAMETERVALUE");
    		}
    
    		#endregion
    	}
