        public static IEnumerable<MethodDeclarationSyntax> BobsFilter(SyntaxTree tree)
        {
            var compilation = Compilation.Create("test", syntaxTrees: new[] { tree });
            var model = compilation.GetSemanticModel(tree);
            var types = new[] { SpecialType.System_Boolean, SpecialType.System_Void };
            var methods = tree.Root.DescendentNodes().OfType<MethodDeclarationSyntax>();
            var publicInternalMethods = methods.Where(m => m.Modifiers.Any(t => t.Kind == SyntaxKind.PublicKeyword || t.Kind == SyntaxKind.InternalKeyword));
            var withoutParameters = publicInternalMethods.Where(m => !m.ParameterList.Parameters.Any());
            var withReturnBoolOrVoid = withoutParameters.Where(m => types.Contains(model.GetSemanticInfo(m.ReturnType).ConvertedType.SpecialType));
            return withReturnBoolOrVoid;
        }
