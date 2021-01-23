    class OrHaving : OrExpression
        {
            public OrHaving(ICriterion lhs, ICriterion rhs) : base(lhs, rhs)
            {
            }
            public override IProjection[] GetProjections()
            {
                return LeftHandSide.GetProjections().Concat(RightHandSide.GetProjections()).ToArray();
            }
        }
