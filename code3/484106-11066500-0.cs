    public partial class LocalTestDataContext
    {
        [Function(Name = "IsNull", IsComposable = true)]
        [return: Parameter(DbType = "NVarChar(MAX)")]
        public string IsNull(
            [Parameter(Name = "field", DbType = "NVarChar(MAX)")] string field,
            [Parameter(Name = "output", DbType = "NVarChar(MAX)")] string output)
        {
            return ((string)(this.ExecuteMethodCall(this,
                    ((MethodInfo)(MethodInfo.GetCurrentMethod())),
                    field, output).ReturnValue));
        }
    }
