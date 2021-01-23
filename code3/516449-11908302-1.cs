    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="System.Xml" #>
    <#@ assembly name="System.Xml.Linq" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Xml.Linq" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="Microsoft.CSharp" #>
    <#@ output extension=".cs" #>
    <#
        var inputFilePath = @"Strings\en\Resources.resw";
    	var provider = new CSharpCodeProvider();
    	string className = CreateClassName(provider);
    
    	SetCurrentDirectory();
    	if (File.Exists(inputFilePath)) {
    #>
    using Windows.ApplicationModel.Resources;
    
    namespace <#= GetNamespace() #> {
    	public static class <#= className #> {
    		private static ResourceLoader _resourceLoader;
    
    		static <#= className #>() {
    			_resourceLoader = new ResourceLoader("Resources");
    		}
    <#
    		foreach (string name in GetResourceKeys(inputFilePath)) {
    #>
    		public static string <#= provider.CreateEscapedIdentifier(name) #> {
    			get { return _resourceLoader.GetString("<#= name #>"); }
    		}
    <#
    		}
    #>
    	}
    }
    <#
    	} 
    #>
    <#+
        private void SetCurrentDirectory() {
    	    Directory.SetCurrentDirectory(Host.ResolvePath(""));
    	}
    
    	private string CreateClassName(CSharpCodeProvider provider) {
    		string name = Path.GetFileNameWithoutExtension(Host.TemplateFile);
    		return provider.CreateEscapedIdentifier(name);
    	}
    
    	private string GetNamespace() {
    		return Host.ResolveParameterValue("directiveId", "namespaceDirectiveProcessor", "namespaceHint");
    	}
    
    	private static IEnumerable<string> GetResourceKeys(string filePath) {
    		XDocument doc = XDocument.Load(filePath);
    		return doc.Root.Elements("data").Select(e => e.Attribute("name").Value);
    	}
    #>
