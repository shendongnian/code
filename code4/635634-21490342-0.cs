		public <#=code.Escape(container)#>()
			: base("name=<#=container.Name#>")
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
