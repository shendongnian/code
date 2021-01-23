    var workspace = Workspace.LoadSolution(path);
    var solution = workspace.CurrentSolution;
    foreach (var project in solution.Projects
        .Where(prj => prj.LanguageServices.Language == "C#"))
    {
        foreach (var doc in project.Documents
            .Where(d => d.SourceCodeKind == SourceCodeKind.Regular
                     && d.LanguageServices.Language == "C#"))
        {
            var tree = SyntaxTree.ParseCompilationUnit(
                doc.GetText(),
                doc.DisplayName);
            // Update the syntax tree
            var newTree = UpdatePredefinedTypes(tree);
    
            solution = solution.UpdateDocument(doc.Id, newTree.Text);
        }
    }
    
    workspace.ApplyChanges(workspace.CurrentSolution, solution);
    // When you run this on a project open in VS it notices the changes
