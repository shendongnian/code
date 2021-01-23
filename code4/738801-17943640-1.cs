    <#@ template inherits="Microsoft.VisualStudio.TextTemplating.VSHost.ModelingTextTransformation" language="C#v3.5" debug="true" hostSpecific="true" #>
    <#@ output extension=".cs" #>
    <#@ Assembly Name="System.dll" #>
    <#@ Assembly Name="System.Core.dll" #>
    <#@ Assembly Name="System.Windows.Forms.dll" #>
    <#@ import namespace="System" #>
    <#@ import namespace="System.IO" #>
    <#@ import namespace="System.Diagnostics" #>
    <#@ import namespace="System.Linq" #>
    <#@ import namespace="System.Collections" #>
    <#@ import namespace="System.Collections.Generic" #> 
    <#
       // insert your template code here the tempalte code will be syntaxhighlighted 
       // and you will have intellisense for all namespaces in the full edition
       string Greeting = "Hello";
    #>
    // This is the output code from your template
    // you only get syntax-highlighting here - not intellisense
    namespace MyNameSpace{
    using System.Collections.Generic;
      class MyGeneratedClass{
         static void main (string[] args){
    	 if(typeof(List<>).ToString() == "yadayadayada" ){System.Console.WriteLine("isYadayadayada");}
           System.Console.WriteLine("<#= typeof(List<>) #>");
         }
      }
    }
     
    <#+
      // Insert any template procedures here
      void foo(){
    	System.Console.WriteLine(typeof(List<>));
    }
    #>
