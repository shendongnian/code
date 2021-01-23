    <#+
    void WriteToSerializableMethod (CodeGenerationTools code, IEnumerable<EdmProperty> primitiveProperties, EntityType entity)
    {
    
    #>
    public <#=code.Escape(entity)#> ToSerializable()
    {
    	return new <#=code.Escape(entity)#>()
    	{
    <#+
    	foreach(var edmProperty in primitiveProperties)
        {
    #>
    	<#=edmProperty.Name#> = this.<#=edmProperty.Name#>,
    <#+
        }
    #>
    	};
    }
    <#+
    }
    #>
