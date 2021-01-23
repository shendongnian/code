        public override HqlTreeNode BuildHql(
            MethodInfo method,
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor
            )
        {
            // Get the CaseBuilder form the arguments.
            var caseBuilder = (arguments[1] as ConstantExpression).Value as CaseBuilder;
            var hqlWhenList = new List<HqlWhen>();
            // Add a HqlWhen for each CaseBuilderOption. 
            foreach (var option in caseBuilder.Options)
            {
                // add the HqlWhen
                hqlWhenList.Add(
                    // create HqlWhen with given treeBuilder.
                    treeBuilder.When(
                        // compare given property with the When of the CaseBuilderOption.
                        treeBuilder.Equality(visitor.Visit(arguments[0]).AsExpression(), treeBuilder.Constant(option.When)),
                        // add the Then value of the CaseBuilderOption
                        treeBuilder.Constant(option.Then)
                    )
                );
            }
            // 
            return 
                // cast the returned value to returntype of CaseBuilder.
                treeBuilder.Cast(
                    // create the HqlCase with the TreeBuilder.
                    treeBuilder.Case(
                        // add the created HqlWhen list.
                        hqlWhenList.ToArray(), 
                        // add the final or else value from the CaseBuilder.
                        treeBuilder.Constant(caseBuilder.ElseValue)
                    ), 
                // the return type for the cast.
                caseBuilder.ReturnType
            );
        }
 
