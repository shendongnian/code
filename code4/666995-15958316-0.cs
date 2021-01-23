    <#@ template debug="true" hostspecific="true" language="C#" #>
    <#@ output extension=".txt" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="Microsoft.VisualStudio.TextTemplating" #>
    <# 
    string templateFile = this.Host.ResolvePath("ClassGeneration.tt");
    string templateContent = File.ReadAllText(templateFile);
    
    TextTemplatingSession session = new TextTemplatingSession();
    session["namespacename"] = "MyNamespace1";
    session["classname"] = "MyClassName";
    
    var sessionHost = (ITextTemplatingSessionHost) this.Host;
    sessionHost.Session = session;
    
    Engine engine = new Engine();
    string generatedContent = engine.ProcessTemplate(templateContent, this.Host);
    
    this.Write(generatedContent);  #>
