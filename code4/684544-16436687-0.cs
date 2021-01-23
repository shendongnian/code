    public ReturnType Read<ReturnType>(string FieldName, object dfVal)
    {
    	if (Res.IsDBNull(Res.GetOrdinal(FieldName)))
    		return dfVal;
    	try {
    		return (ReturnType)Res.GetValue(Res.GetOrdinal(FieldName));
    	} catch (Exception ex) {
    		return dfVal;
    	}
    }
