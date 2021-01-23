    <#@ template debug="false" hostspecific="True" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ Assembly Name="System.Core.dll" #>
    <#@ dte processor="T4Toolbox.DteProcessor" #>
    <#@ TransformationContext processor="T4Toolbox.TransformationContextProcessor" #>
    <#@ assembly name="System.Xml" #>
    <#@ assembly name="EnvDTE" #>
    <#@ assembly name="EnvDTE80" #>
    <#@ import namespace="T4Toolbox" #>
    <#@ import namespace="EnvDTE" #> 
    <#@ import namespace="EnvDTE80" #>
    <#
        ProjectItem projectItem = TransformationContext.FindProjectItem("Dictionaries.cs");
        FileCodeModel codeModel = projectItem.FileCodeModel;
    
        foreach (CodeElement element in codeModel.CodeElements)
        {
            CodeNamespace ns = element as CodeNamespace;
            if(ns != null)
            {
                foreach(CodeElement ele in ns.Children)
                {
                    CodeClass cl = ele as CodeClass;
    
                    if(cl != null && cl.Name == "Dictionaries")
                    {
                        foreach(CodeElement member in cl.Members)
                        {
                            // Generate stuff...
                            this.WriteLine(member.Name);
                        }
                    }
                }
            }
        }
    #>
