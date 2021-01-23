    <#@ template language="C#" debug="true" #>
    <#@ output extension=".cs" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.Collections.Generic" #>
        
    using System;
    using System.Collections.Generic;
        
    namespace Test
    {
        public class <#= this.ClassName #> //Expression Block
        {       
        }
    }
        
    <#+ //Class feature block
        public string ClassName = "MyClass";
    #>
