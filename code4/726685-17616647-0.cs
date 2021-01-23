    <#
        var hostServiceProvider = this.Host as IServiceProvider;
        var dte = hostServiceProvider.GetService(typeof(EnvDTE.DTE)) as EnvDTE.DTE;
        var project = dte.Solution.Projects.Cast<EnvDTE.Project>().First();
        var configHelper = ConfigurationHelper.GetDefaultConfiguration(project);
    
        foreach(var appsetting in configHelper.AppSettings)
        {
    #><#= appsetting.Key #> = <#= appsetting.Value #>
      <#}
    #>
