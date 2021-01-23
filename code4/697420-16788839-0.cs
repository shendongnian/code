    public <#=Code.Escape(container)#>()
        : base("name=<#=container.Name#>")
    {
    <#
        WriteLazyLoadingEnabled(container);
    #>
    }
