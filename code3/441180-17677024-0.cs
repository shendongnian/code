	private static IDocument RemoveUnusedImportDirectives(IDocument document)
	{
		var root = document.GetSyntaxRoot();
		var semanticModel = document.GetSemanticModel();
        // An IDocument can refer to both a CSharp as well as a VisualBasic source file.
        // Therefore we need to distinguish those cases and provide appropriate casts.  
        // Since the question was tagged c# only the CSharp way is provided.
		switch (document.LanguageServices.Language)
		{
			case LanguageNames.CSharp:
				var oldUsings = ((CompilationUnitSyntax)root).Usings;
				var unusedUsings = ((SemanticModel)semanticModel).GetUnusedImportDirectives();
				var newUsings = Syntax.List(oldUsings.Where(item => !unusedUsings.Contains(item)));
				root = ((CompilationUnitSyntax)root).WithUsings(newUsings);
				document = document.UpdateSyntaxRoot(root);
                break;
		
    	    case LanguageNames.VisualBasic:
				// TODO
				break;
		}
		return document;
	}
