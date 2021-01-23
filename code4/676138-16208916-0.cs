    <#
	// get a reference to the project of this t4 template
	var project = VisualStudioHelper.CurrentProject;
	// get all class items from the code model
	var allClasses = VisualStudioHelper.GetAllCodeElementsOfType(project.CodeModel.CodeElements, EnvDTE.vsCMElement.vsCMElementClass, false);
	// iterate all classes
	foreach(EnvDTE.CodeClass codeClass in allClasses)
    {
		// get all methods implemented by this class
		var allFunctions = VisualStudioHelper.GetAllCodeElementsOfType(codeClass.Members, EnvDTE.vsCMElement.vsCMElementFunction, false);
		foreach(EnvDTE.CodeFunction function in allFunctions)
        {
			// get all attributes this method is decorated with
			var allAttributes = VisualStudioHelper.GetAllCodeElementsOfType(function.Attributes, vsCMElement.vsCMElementAttribute, false);
			// check if the System.ObsoleteAttribute is present
			if (allAttributes.OfType<EnvDTE.CodeAttribute>()
							 .Any(att => att.FullName == "System.ObsoleteAttribute"))
            {
			#><#= function.FullName #>
    <#	        
			}
        }
    }
    #>
