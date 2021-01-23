    foreach (var projectId in solution.ProjectIds)
    {
        var project = solution.GetProject(projectId);
        Annotator annotator = new Annotator();
        foreach (var documentId in project.DocumentIds)
        {
            var document = project.GetDocument(documentId);
            CompilationUnitSyntax compilationUnit = (CompilationUnitSyntax)document.GetSyntaxRoot();
            var mcu = annotator.AddAnnotations(compilationUnit);
            solution = document.UpdateSyntaxRoot(mcu).Project.Solution;
        }
    }
