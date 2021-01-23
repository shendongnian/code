    static void Main(string[] args)
    {
      Assembly clrAssembly = Assembly.LoadFrom(@"Path\to\your\assembly.dll");
      string sql = CreateFunctionsFromAssembly(clrAssembly, permissionSetType.UNSAFE);
      File.WriteAllText(sqlFile, sql);
    }
    /// <summary>
    /// permissions available for an assembly dll in sql server
    /// </summary>
    public enum permissionSetType { SAFE, EXTERNAL_ACCESS, UNSAFE };
    
    /// <summary>
    /// generate sql from an assembly dll with all functions with attribute SqlFunction
    /// </summary>
    /// <param name="clrAssembly">assembly object</param>
    /// <param name="permissionSet">sql server permission set</param>
    /// <returns>sql script</returns>
    public static string CreateFunctionsFromAssembly(Assembly clrAssembly, permissionSetType permissionSet)
    {
        const string sqlTemplate = @"
          -- Delete all functions from assembly '{0}'
          DECLARE @sql NVARCHAR(MAX)
          SET @sql = 'DROP FUNCTION ' + STUFF(
            (
            	SELECT
            		', ' + assembly_method 
            	FROM
            		sys.assembly_modules
            	WHERE
            		assembly_id IN (SELECT assembly_id FROM sys.assemblies WHERE name = '{0}')
            	FOR XML PATH('')
            ), 1, 1, '')
          IF @sql IS NOT NULL EXEC sp_executesql @sql
          GO
          
          -- Delete existing assembly '{0}' if necessary
          IF EXISTS(SELECT 1 FROM sys.assemblies WHERE name = '{0}')
            DROP ASSEMBLY {0};
          GO
          
          {1}
          GO
          
          -- Create all functions from assembly '{0}'
        ";
        string assemblyName = clrAssembly.GetName().Name;
        StringBuilder sql = new StringBuilder();
        sql.AppendFormat(sqlTemplate, assemblyName, CreateSqlFromAssemblyDll(clrAssembly, permissionSet));
        foreach (Type classInfo in clrAssembly.GetTypes())
        {
            foreach (MethodInfo methodInfo in classInfo.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly))
            {
                if (Attribute.IsDefined(methodInfo, typeof(SqlFunctionAttribute)))
                {
                    StringBuilder methodParameters = new StringBuilder();
                    bool firstParameter = true;
                    foreach (ParameterInfo paramInfo in methodInfo.GetParameters())
                    {
                        if (firstParameter)
                             firstParameter = false;
                        else
                            methodParameters.Append(", ");
                        methodParameters.AppendFormat(@"@{0} {1}", paramInfo.Name, ConvertClrTypeToSql(paramInfo.ParameterType));
                    }
                    string returnType = ConvertClrTypeToSql(methodInfo.ReturnParameter.ParameterType);
                    string methodName = methodInfo.Name;
                    string className = (classInfo.Namespace == null ? "" : classInfo.Namespace + ".") + classInfo.Name;
                    string externalName = string.Format(@"{0}.[{1}].{2}", assemblyName, className, methodName);
                    sql.AppendFormat(@"CREATE FUNCTION {0}({1}) RETURNS {2} AS EXTERNAL NAME {3};"
                                    , methodName, methodParameters, returnType, externalName)
                       .Append("\nGO\n");
                }
            }
        }
        return sql.ToString();
    }
    /// <summary>
    /// Generate sql script to create assembly
    /// </summary>
    /// <param name="clrAssembly"></param>
    /// <param name="permissionSet">sql server permission set</param>
    /// <returns></returns>
    public static string CreateSqlFromAssemblyDll(Assembly clrAssembly, permissionSetType permissionSet)
    {
        const string sqlTemplate = @"
          -- Create assembly '{0}' from dll
          CREATE ASSEMBLY [{0}] 
            AUTHORIZATION [dbo]
            FROM 0x{2}
            WITH PERMISSION_SET = {1};
        ";
        StringBuilder bytes = new StringBuilder();
        using (FileStream dll = File.OpenRead(clrAssembly.Location))
        {
            int @byte;
            while ((@byte = dll.ReadByte()) >= 0)
                bytes.AppendFormat("{0:X2}", @byte);
        }
        string sql = String.Format(sqlTemplate, clrAssembly.GetName().Name, permissionSet, bytes);
        return sql;
    }
    /// <summary>
    /// Convert clr type to sql type
    /// </summary>
    /// <param name="clrType">clr type</param>
    /// <returns>sql type</returns>
    private static string ConvertClrTypeToSql(Type clrType)
    {
        switch (clrType.Name)
        {
            case "SqlString":
                return "NVARCHAR(MAX)";
            case "SqlDateTime":
                return "DATETIME";
            case "SqlInt16":
                return "SMALLINT";
            case "SqlInt32":
                return "INTEGER";
            case "SqlInt64":
                return "BIGINT";
            case "SqlBoolean":
                return "BIT";
            case "SqlMoney":
                return "MONEY";
            case "SqlSingle":
                return "REAL";
            case "SqlDouble":
                return "DOUBLE";
            case "SqlDecimal":
                return "DECIMAL(18,0)";
            case "SqlBinary":
                return "VARBINARY(MAX)";
            default:
                throw new ArgumentOutOfRangeException(clrType.Name + " is not a valid sql type.");
        }
    }
