    public <#=Code.Escape(container)#>()
        : base("name=<#=container.Name#>")
    {
        this.Configuration.LazyLoadingEnabled = false;
        // more setup here, e.g. this.Configuration.ProxyCreationEnabled = false;    
    }
