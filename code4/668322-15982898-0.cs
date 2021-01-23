    <#@ assembly name="EnvDte" #>
    <#
        var visualStudio = ( this.Host as IServiceProvider )
            .GetService( typeof( EnvDTE.DTE ) ) as EnvDTE.DTE;
        var project = visualStudio.Solution
            .FindProjectItem( this.Host.TemplateFile )
            .ContainingProject as EnvDTE.Project;
    #>
    
