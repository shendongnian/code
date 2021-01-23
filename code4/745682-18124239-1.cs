    public void Execute(IDataContext context, DelegateExecute nextExecute)
	{
		// Fetch active solution from context.
		ISolution solution = context.GetData(JetBrains.ProjectModel.DataContext.DataConstants.SOLUTION);
		if (solution == null)
			return;
		var declaredElements = context.GetData(DataConstants.DECLARED_ELEMENTS);
		if (declaredElements == null || declaredElements.IsEmpty())
			return;
		IDeclaredElement declaredElement = declaredElements.First();
		var classElement = declaredElement as IClass;
		if (classElement != null)
		{
			// As a class can be declared in multiple files (partial classes) we enumerate all
			// declarations and choose the first one
			var declarations = classElement.GetDeclarations();
			var classDeclaration = declarations.First() as IClassDeclaration;
			var properties = classDeclaration.PropertyDeclarations.Where(p => p.Type.IsString());
			foreach (var propertyDeclaration in properties)
			{		
				PsiManager.GetInstance(solution).DoTransaction(() =>
				{
					classDeclaration.RemoveClassMemberDeclaration(propertyDeclaration);
				},
				"PsiTransactionCommand");
			}
		}
	}
