    string namespaceString = "MyTypeNamespace";
    string codeString = "public class TestClass {}";
    string snippetValue = string.Format(@"
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace {0}
    {{
    
    {1}
    
    }}", namespaceString, codeString, Environment.NewLine);
    
    var snippetCompileUnit = new CodeSnippetCompileUnit {Value = snippetValue};
