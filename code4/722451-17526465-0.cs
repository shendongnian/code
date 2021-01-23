        <# var project = VisualStudioHelper.CurrentProject;
        // get all class items from the code model
        var allClasses = VisualStudioHelper.GetAllCodeElementsOfType(project.CodeModel.CodeElements, EnvDTE.vsCMElement.vsCMElementClass, false);
        // iterate all classes
        foreach(EnvDTE.CodeClass codeClass in allClasses)
        {
            // iterate all properties
            var allProperties = VisualStudioHelper.GetAllCodeElementsOfType(codeClass.Members, EnvDTE.vsCMElement.vsCMElementProperty, true);
            foreach(EnvDTE.CodeProperty property in allProperties)
            {
                // check if it is decorated with an "Input"-Attribute
                if (property.Attributes.OfType<EnvDTE.CodeAttribute>().Any(a => a.FullName == "Input"))
                {
                    ...
                }
            }
        }
        #>
