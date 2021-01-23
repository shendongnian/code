    <#@ template debug="false" hostspecific="true" language="C#" #>
    <#@ assembly name="System.Core" #>
    <#@ assembly name="System.Xml" #>
    <#@ assembly name="System.Xml.Linq" #>
    <#@ assembly name="EnvDTE" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Xml.Linq" #>
    <#@ import namespace="System.Collections.Generic" #>
    <#@ import namespace="Microsoft.CSharp" #>
    <#@ import namespace="EnvDTE" #>
    <#@ output extension=".cs" #>
    <#
        DTE env = GetVSEnvironment();
        var inputFilePath = @"Resources\Strings\en\Resources.resw";
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
        		_resourceLoader = new ResourceLoader("<#= GetResourcePath(env) #>");
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
        } else {
    		throw new FileNotFoundException(String.Format("Unable to find Resource file: {0}", inputFilePath)); 
    	} 
    #>
    <#+
        private DTE GetVSEnvironment() {
    		DTE env = null;
    		var provider = Host as IServiceProvider;
    		if (provider != null) {
    			env = provider.GetService(typeof(DTE)) as DTE;
    		}
    
    		if (env == null) {
    			throw new InvalidOperationException("Template must be executed from Visual Studio");
    		}
    
    		return env;
    	}
    
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
    
    	private string GetResourcePath(DTE env) {
    		Project project = env.Solution.FindProjectItem(Host.TemplateFile).ContainingProject;
    		string assemblyName = project.Properties.Item("AssemblyName").Value.ToString();
    		return assemblyName + "/Resources";
    	}
        
        private static IEnumerable<string> GetResourceKeys(string filePath) {
        	XDocument doc = XDocument.Load(filePath);
        	return doc.Root.Elements("data").Select(e => e.Attribute("name").Value);
        }
    #>
