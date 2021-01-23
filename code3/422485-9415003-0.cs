    using System;
    using System.Reflection;
    using System.CodeDom.Compiler;
    using Microsoft.CSharp;
    
    void Main()
    {
    	StringBuilder dc = new StringBuilder(512);
    	dc.Append("public class FileRow");
    	dc.Append("{");
    	//dc.Append("[FileHelpers.FieldQuoted('\"', QuoteMode.OptionalForBoth)]");
    	dc.Append("public string Borrower_First_Name;");
    	//dc.Append("[FileHelpers.FieldQuoted('\"', QuoteMode.OptionalForBoth)]");
    	dc.Append("public string Borrower_Last_Name;");
    	dc.Append("public string Borrower_Email;");
    	dc.Append("}");
    	
    	CompilerResults compiledResult = CompileScript(dc.ToString());
    		
    	if (compiledResult.Errors.HasErrors)
    	{
    		Console.WriteLine (compiledResult.Errors[0].ErrorText);
    		throw new InvalidOperationException("Invalid Expression syntax");
    	}
    		
    	Assembly assembly = compiledResult.CompiledAssembly;
        // This is just for testing purposes.
    	FieldInfo field = assembly.GetType("FileRow").GetField("Borrower_First_Name");    		
    	Console.WriteLine (field.Name);    		
    	Console.WriteLine (field.FieldType);
    }
    	
    public static CompilerResults CompileScript(string source) 
    { 
    	CompilerParameters parms = new CompilerParameters(); 
    
    	parms.GenerateExecutable = false; 
    	parms.GenerateInMemory = true; 
    	parms.IncludeDebugInformation = false; 
    
    	CodeDomProvider compiler = CSharpCodeProvider.CreateProvider("CSharp"); 
    
    	return compiler.CompileAssemblyFromSource(parms, source); 
    } 
