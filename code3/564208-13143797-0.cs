    public void CompileAndExecute(string CodeBody)
    {
    	// Create the compile unit
    	CodeCompileUnit ccu = CreateCode(CodeBody);
    
    	// Compile the code	
    	CompilerParameters comp_params = new CompilerParameters();
    	comp_params.GenerateExecutable = false;
    	comp_params.GenerateInMemory = true;
    	comp_params.TreatWarningsAsErrors = true;
    	comp_results = code_provider.CompileAssemblyFromDom(comp_params, ccu);
    
    	// CHECK COMPILATION RESULTS
    	if (!comp_results.Errors.HasErrors)
    	{
    	    Type output_class_type = comp_results.CompiledAssembly.GetType("TestNamespace.TestClass");
    
    	    if (output_class_type != null)    
    	    {    
    	        MethodInfo compiled_method = output_class_type.GetMethod("TestMethod", BindingFlags.Static | BindingFlags.Public);    
    	        if (compiled_method != null)    
    	        {    
    	            Delgate created_delegate = Delegate.CreateDelegate(typeof(System.Windows.Forms.MethodInvoker), compiled_method);
    	            if (created_delegate != null)
    	            {
    	                // Run the code
    	                created_delegate.DynamicInvoke();
    	            }
    	        }
            }
    	}
    	else
    	{
    	    foreach (CompilerError error in comp_results.Errors)
    	    {
    	        // report the error
    	    }
    	}
    }
    
    public CodeCompileUnit CreateCode(string CodeBody)
    {
    	CodeNamespace code_namespace = new CodeNamespace("TestNamespace");
    	
    	// add the class to the namespace, add using statements
    	CodeTypeDeclaration code_class = new CodeTypeDeclaration("TestClass");
    	code_namespace.Types.Add(code_class);
    	code_namespace.Imports.Add(new CodeNamespaceImport("System"));
    	
    	// set function details
    	CodeMemberMethod method = new CodeMemberMethod();
    	method.Attributes = MemberAttributes.Public | MemberAttributes.Static;
    	method.ReturnType = new CodeTypeReference(typeof(void));
    	method.Name = "TestMethod";
    
    	// add the user typed code
    	method.Statements.Add(new CodeSnippetExpression(CodeBody));
    	
    	// add the method to the class
    	code_class.Members.Add(method);
    
    	// create a CodeCompileUnit to pass to our compiler
    	CodeCompileUnit ccu = new CodeCompileUnit();
    	ccu.Namespaces.Add(code_namespace);
    
    	return ccu;
    }
    
