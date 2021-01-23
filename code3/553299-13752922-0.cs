    public <#=Code.Escape(container)#>()
            : base("name=<#=container.Name#>")
        {
    <#
            WriteLazyLoadingEnabled(container);
    #>
    		//add the following line of code
    
    		this.Configuration.ProxyCreationEnabled = false;
        }
