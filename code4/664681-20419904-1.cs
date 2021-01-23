    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ output extension=".cs" #>
    <#@ assembly name="System.Windows.Forms" #>
    
    <#@ import namespace="System.Resources" #>
    <#@ import namespace="System.Collections" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.ComponentModel.Design" #>
    
    <#
    
        var nameSpace = "WindowsFormsApplication1";
        var enumName = "CustomEnum";
    
        var fileName = "CustomResource.resx";
        var filePath = Path.Combine(Path.GetDirectoryName(this.Host.ResolvePath("")), "WindowsFormsApplication10", fileName);
    
        using (var reader = new ResXResourceReader(filePath))
        {
    
            reader.UseResXDataNodes = true;
    #>
    
    namespace <#=nameSpace#>
    {
    
        public enum <#=enumName#>
        {
    
            Undefined,
    
            <#  foreach(DictionaryEntry entry in reader) { 
            
                var name = entry.Key;
                var node = (ResXDataNode)entry.Value;
                var value = node.GetValue((ITypeResolutionService) null);
                var comment = node.Comment;
                var summary = value;
                if (!String.IsNullOrEmpty(comment)) summary += " - " + comment;
            #>
            
            /// <summary>
            /// <#= summary #>
            /// </summary>
            <#= name #>,
    
            <# } #>
    
        }
    
    }
    
    
    <#
        }
    #>
