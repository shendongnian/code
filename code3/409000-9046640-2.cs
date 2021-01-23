    XName xBinary = "binary";
    XName xLiteral = "literal";
    Expression Visit(XElement elt)
    {
        if (elt.Name == xBinary)
        {
            return VisitBinary(elt);
        }
        else if (elt.Name == xLiteral)
        {
            return VisitLiteral(elt);
        } // ...
        throw new NotSupportedException();
    }
