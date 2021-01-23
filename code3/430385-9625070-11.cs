    var workspace = Workspace.LoadSolution(info.FullName);
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
            var newTree = UpdatePredefinedTypes(tree);
            solution = solution.UpdateDocument(doc.Id, newTree.Text);
        }
    }
    workspace.ApplyChanges(workspace.CurrentSolution, solution);
    // when running this in VS on itself it correctly updates the project!
