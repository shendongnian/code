    public void BeginNamespace(CodeGenerationTools code)
    {
        var codeNamespace = code.VsNamespaceSuggestion();
        if (!String.IsNullOrEmpty(codeNamespace))
        {
    #>
    namespace <#=code.EscapeNamespace(codeNamespace)#>
    {
    <#+
            PushIndent("    ");
        }
    }
    
    public void EndNamespace(CodeGenerationTools code)
    {
        if (!String.IsNullOrEmpty(code.VsNamespaceSuggestion()))
        {
            PopIndent();
    #>
    }
    <#+
        }
    }
