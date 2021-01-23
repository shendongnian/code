    ////////
    ////////  Write SimpleType Properties.
    ////////
    private void WriteSimpleTypeProperty(EdmProperty simpleProperty, CodeGenerationTools code)
    {
        MetadataTools ef = new MetadataTools(this);
    #>
    /// <summary>
    /// <#=SummaryComment(simpleProperty)#>
    /// </summary><#=LongDescriptionCommentElement(simpleProperty, 1)#>
    [EdmScalarPropertyAttribute(EntityKeyProperty=       <#=code.CreateLiteral(ef.IsKey(simpleProperty))#>, IsNullable=<#=code.CreateLiteral(ef.IsNullable(simpleProperty))#>)]
    [DataMemberAttribute()]
    <#=code.SpaceAfter(NewModifier(simpleProperty))#><#=Accessibility.ForProperty(simpleProperty)#> <#=MultiSchemaEscape(simpleProperty.TypeUsage, code)#> <#=code.Escape(simpleProperty)#>
    {
        <#=code.SpaceAfter(Accessibility.ForGetter(simpleProperty))#>get
        {
    <#+             if (ef.ClrType(simpleProperty.TypeUsage) == typeof(byte[]))
                {
    #>
            return StructuralObject.GetValidValue(<#=code.FieldName(simpleProperty)#>);
    <#+
                }
                else
                {
    #>
            return <#=code.FieldName(simpleProperty)#>;
    <#+
                }
    #>
        }
        <#=code.SpaceAfter(Accessibility.ForSetter((simpleProperty)))#>set
        {
    <#+
            **//if (ef.IsKey(simpleProperty)) 
            **//{
                if (ef.ClrType(simpleProperty.TypeUsage) == typeof(byte[]))
                {
    #>
            if (!StructuralObject.BinaryEquals(<#=code.FieldName(simpleProperty)#>, value))
    <#+
                }
                else
                {
     #>
            if (<#=code.FieldName(simpleProperty)#> != value)
    <#+
                }
    #>
            {
    <#+
        PushIndent(CodeRegion.GetIndent(1));
            **//}
    #>
            <#=ChangingMethodName(simpleProperty)#>(value);
            ReportPropertyChanging("<#=simpleProperty.Name#>");
            <#=code.FieldName(simpleProperty)#> = <#=CastToEnumType(simpleProperty.TypeUsage, code)#>StructuralObject.SetValidValue(<#=CastToUnderlyingType(simpleProperty.TypeUsage, code)#>value<#=OptionalNullableParameterForSetValidValue(simpleProperty, code)#>, "<#=simpleProperty.Name#>");
            ReportPropertyChanged("<#=simpleProperty.Name#>");
            <#=ChangedMethodName(simpleProperty)#>();
    <#+
        **//if (ef.IsKey(simpleProperty))
            **//{
        PopIndent();
    #>
            }
    <#+
            **//}
    #>
        }
    }
