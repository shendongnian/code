    Expression VisitLiteral(XElement elt)
    {
        Debug.Assert(elt.Name == xLiteral);
        return Expression.Constant((int)elt);
    }
    Expression VisitBinary(XElement elt)
    {
        Debug.Assert(elt.Name == xBinary);
        Debug.Assert(elt.Elements().Count() >= 3);
        var lhs = elt.Elements().ElementAt(0);
        var op = elt.Elements().ElementAt(1);
        var rhs = elt.Elements().ElementAt(2);
        switch((string)op)
        {
        case "+":
            // by chaining LHS and RHS to Visit we allow the tree to be constructed
            // properly as Visit performs the per-element dispatch
            return Expression.Add(Visit(lhs), Visit(rhs));
        case "&&":
            return Expression.AndAlso(Visit(lhs), Visit(rhs));
        default:
            throw new NotSupportedException();
        }
    }
