    <#=Accessibility.ForType(container)#> partial class <#=code.Escape(container)#> : DbContext
    {
        public <#=code.Escape(container)#>()
            : base("name=<#=container.Name#>")
        {
    	    Database.CommandTimeout = 180;
    <#
    if (!loader.IsLazyLoadingEnabled(container))
    {
    #>
            this.Configuration.LazyLoadingEnabled = false;
    <#
    }
