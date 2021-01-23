     var solution = (Solution2) _applicationObject.Solution;
    var projects = solution.Projects;
    var activeProject = projects
        .OfType<Project>()
        .First();
    
    // locate my class.
    var myClass = GetAllCodeElementsOfType(
        activeProject.CodeModel.CodeElements,
        vsCMElement.vsCMElementClass, false)
        .OfType<CodeClass2>()
        .First(x => x.Name == "Program");
    
    // locate my attribute on class.
    var mySpecialAttrib = myClass
        .Attributes
        .OfType<CodeAttribute2>()
        .First();
    
    
    
    var attributeArgument = mySpecialAttrib.Arguments
        .OfType<CodeAttributeArgument>()
        .First();
    
    string myType = Regex.Replace(
        attributeArgument.Value, // typeof(MyType)
        "^typeof.*\\((.*)\\)$", "$1"); // MyType*/
    
    var codeNamespace = myClass.Namespace;
    var classNamespaces = new List<string>();
    
    while (codeNamespace != null)
    {
        var codeNs = codeNamespace;
        var namespaceName = codeNs.FullName;
    
        var foundNamespaces = new List<string> {namespaceName};
    
        // generate namespaces from usings.
        var @usings = codeNs.Children
            .OfType<CodeImport>()
            .Select(x =>
                new[]
                {
                    x.Namespace,
                    namespaceName + "." + x.Namespace
                })
            .SelectMany(x => x)
            .ToList();
    
        foundNamespaces.AddRange(@usings);
    
        // prepend all namespaces:
        var extra = (
            from ns2 in classNamespaces
            from ns1 in @usings
            select ns1 + "." + ns2)
            .ToList();
    
        classNamespaces.AddRange(foundNamespaces);
        classNamespaces.AddRange(extra);
    
        codeNamespace = codeNs.Parent as CodeNamespace;
        if (codeNamespace == null)
        {
            var codeModel = codeNs.Parent as FileCodeModel2;
            if (codeModel == null) return;
    
            var elems = codeModel.CodeElements;
            if (elems == null) continue;
    
            var @extraUsings = elems
                .OfType<CodeImport>()
                .Select(x => x.Namespace);
    
            classNamespaces.AddRange(@extraUsings);
        }
    }
    
    // resolve to a type!
    var typeLocator = new EnvDTETypeLocator();
    var resolvedType = classNamespaces.Select(type =>
            typeLocator.FindTypeExactMatch(activeProject, type + "." + myType))
        .FirstOrDefault(type => type != null);
