    [global::System.Data.Linq.Mapping.FunctionAttribute(Name="PFO.PFOValidateUpdateData")]
            public ISingleResult<PFOValidData> PFOValidateUpdateData([global::System.Data.Linq.Mapping.ParameterAttribute(Name = "PfoIDs", DbType = "Xml")] System.Xml.Linq.XElement pfoIDs, [global::System.Data.Linq.Mapping.ParameterAttribute(Name = "UserID", DbType = "UniqueIdentifier")] System.Nullable<System.Guid> userID)
    		{
    			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pfoIDs, userID);
    			return ((ISingleResult<PFOValidData>)(result.ReturnValue));
    		}
