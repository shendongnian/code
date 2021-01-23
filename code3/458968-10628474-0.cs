    <#@ template hostspecific="true' #>
    <#
        ProjectTraverser.Host = Host;
    #>
    <#+ 
    public class ProjectTraverser 
    {
        public static ITextTemplatingEngineHost Host { get; set; }
        public void Traverse() 
        { 
            var a = Host; 
        } 
    } 
    #> 
