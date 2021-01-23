     public <#=code.Escape(container)#>(string myString)
            : base(myString)
        {
    <#
    if (!loader.IsLazyLoadingEnabled(container))
    {
    #>
            this.Configuration.LazyLoadingEnabled = false;
    <#
    }
    #>
        }  
