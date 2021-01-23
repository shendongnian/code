        var project = env.ActiveDocument.ProjectItem.ContainingProject;
    foreach(EnvDTE.CodeElement element in project.CodeModel.CodeElements)
    {
        if (element.Kind == EnvDTE.vsCMElement.vsCMElementClass)
        {
            var myClass = (EnvDTE.CodeClass)element;
            // do stuff with that class here
        }
    }
