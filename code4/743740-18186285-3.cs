    if (diagonists.Count() > 0)
    {
        var diagitems = diagonists.Where(d => d.Info.MessageIdentifier.ToString().Equals("CS0168")).ToList();
        
        if (diagitems != null)
        {
            var ditem = diagitems.Where(d => d.Location.GetLineSpan(false).StartLinePosition.Line == node.GetLocation().GetLineSpan(false).StartLinePosition.Line).FirstOrDefault();
                            
            if (ditem != null)
            {
                node = node.WithLeadingTrivia(Syntax.ParseTrailingTrivia("//"));                            
            }
        }
    }
    
    return base.VisitVariableDeclaration(node);
